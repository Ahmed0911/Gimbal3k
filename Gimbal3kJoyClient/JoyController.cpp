#include "JoyController.h"
#include <iostream>
#include <chrono>

JoyController::JoyController(std::string ipaddress) : m_JoyConnected(false), m_gimbalIPAddress(ipaddress)
{
	// Init winsock WINDOWS ONLY
	WSADATA wsaData;
	WSAStartup(MAKEWORD(2, 2), &wsaData);

	// create socket
	m_udpSocket = socket(AF_INET, SOCK_DGRAM, 0);
	if (m_udpSocket == SOCKET_ERROR)
	{
		std::cout << "Socket Error" << std::endl;
		return;
	}
}

JoyController::~JoyController()
{
	WSACleanup();
}

void JoyController::execute()
{
	// get joystick state
	XINPUT_GAMEPAD joyInputs = getJoyInputs();

	if (m_JoyConnected)
	{
		// process only if joy is connected
		processJoystickCommands(joyInputs);

		// send data
		sendUDPrefValues();
	}
	else
	{
		std::cout << "Joy FAILED" << std::endl;
	}
}

XINPUT_GAMEPAD JoyController::getJoyInputs()
{
	XINPUT_STATE state{};

	if (XInputGetState(0, &state) == ERROR_SUCCESS)
	{
		m_JoyConnected = true; // joystick OK
	}
	else
	{
		m_JoyConnected = false; // no joystick
	}
	
	return state.Gamepad;
}

bool JoyController::isClicked(WORD currentState, WORD button)
{
	bool clicked = false;

	if ( (currentState & button) )
	{
		// check last state
		if ((m_PreviousButtonsState & button) == 0)
		{
			clicked = true;
		}
	}

	return clicked;
}

void JoyController::processJoystickCommands(XINPUT_GAMEPAD joyState)
{
	bool displayNewValues = false;

	// set timestamp
	m_PacketToSend = {};
	//m_PacketToSend.timestamp = std::chrono::duration_cast<std::chrono::microseconds>(std::chrono::system_clock::now().time_since_epoch()).count();

	// set header
	m_PacketToSend.Header24 = 0x24;
	m_PacketToSend.Header42 = 0x42;
	m_PacketToSend.Type = 0x30; // command

	bool manualMode = false;
	if (manualMode)
	{
		m_PacketToSend.Command = 0x01; // manual

		// Check Settings Buttons
		//if (isClicked(joyState.wButtons, XINPUT_GAMEPAD_DPAD_UP))

		// Pan Mode
		if (std::abs(joyState.sThumbLX) < DEADZONEANVAL) // deadzone
		{
			m_PacketToSend.RefPan = 0;
		}
		else
		{
			if (joyState.sThumbLX > 0)
			{
				float inputVal = (float)(joyState.sThumbLX - DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				m_PacketToSend.RefPan = inputVal;
				//std::cout << "Pan: " << m_PacketToSend.RefPan << std::endl;
			}
			else
			{
				float inputVal = (float)(joyState.sThumbLX + DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				m_PacketToSend.RefPan = inputVal;
				//std::cout << "Pan: " << m_PacketToSend.RefPan << std::endl;
			}
		}

		// Tilt Mode
		if (std::abs(joyState.sThumbLY) < DEADZONEANVAL) // deadzone
		{
			m_PacketToSend.RefTilt = 0;
		}
		else
		{
			if (joyState.sThumbLY > 0)
			{
				float inputVal = (float)(joyState.sThumbLY - DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				m_PacketToSend.RefTilt = inputVal;
				//std::cout << "Tilt: " << m_PacketToSend.RefTilt << std::endl;
			}
			else
			{
				float inputVal = (float)(joyState.sThumbLY + DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				m_PacketToSend.RefTilt = inputVal;
				//std::cout << "Tilt: " << m_PacketToSend.RefTilt << std::endl;
			}
		}
	}
	else
	{
		// Auto Mode
		m_PacketToSend.Command = 0x02; // Auto Mode

		float divider = 2;

		// Pan Mode
		if (std::abs(joyState.sThumbLX) > DEADZONEANVAL) // deadzone
		{
			if (joyState.sThumbLX > 0)
			{
				float inputVal = (float)(joyState.sThumbLX - DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				
				if (m_refPan < 175) m_refPan += (inputVal / divider);
				//std::cout << "Pan: " << m_refPan << std::endl;
			}
			else
			{
				float inputVal = (float)(joyState.sThumbLX + DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				
				if (m_refPan > -175) m_refPan += (inputVal / divider);
				//std::cout << "Pan: " << m_refPan << std::endl;
			}
		}

		// Tilt Mode
		if (std::abs(joyState.sThumbLY) > DEADZONEANVAL) // deadzone
		{
			if (joyState.sThumbLY > 0)
			{
				float inputVal = (float)(joyState.sThumbLY - DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				if (m_refTilt < 85) m_refTilt += (inputVal / divider);
				//std::cout << "Tilt: " << m_refTilt << std::endl;
			}
			else
			{
				float inputVal = (float)(joyState.sThumbLY + DEADZONEANVAL) / (32768.0f - DEADZONEANVAL);
				if (m_refTilt > -85) m_refTilt += (inputVal / divider);
				//std::cout << "Tilt: " << m_refTilt << std::endl;
			}
		}

		m_PacketToSend.RefPan = m_refPan;
		m_PacketToSend.RefTilt = m_refTilt;
	}

	// remember current button values for next iteration
	m_PreviousButtonsState = joyState.wButtons;
}

void JoyController::sendUDPrefValues()
{
	sockaddr_in destinationAddr{};
	destinationAddr.sin_family = AF_INET;
	destinationAddr.sin_port = htons(UDPPORT); // joy port
	destinationAddr.sin_addr.s_addr = inet_addr(m_gimbalIPAddress.c_str());

	sendto(m_udpSocket, (const char*)&m_PacketToSend, sizeof(m_PacketToSend), 0, reinterpret_cast<sockaddr*>(&destinationAddr), sizeof(destinationAddr));
}
