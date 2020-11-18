#pragma once
#include <Windows.h>
#include <Xinput.h>
#include <stdint.h>
#include <string>

#pragma pack(push,1)
struct ClientUDPpacket
{
	uint8_t Header42;
	uint8_t Header24;
	uint8_t Type; // 0x30 for commands
	uint32_t Command; // 0 - disabled, 1 - manual ctrl, 2 - auto ctrl
	float RefPan; // [-1...1] or deg for auto
	float RefTilt; // [-1...1] or deg for auto
};
#pragma pack(pop)

class JoyController
{
	public:
		JoyController(std::string ipaddress);
		virtual ~JoyController();
		void execute();
	
	private:
		bool m_JoyConnected;
		std::string m_gimbalIPAddress;
		XINPUT_GAMEPAD getJoyInputs();
		void processJoystickCommands(XINPUT_GAMEPAD joyState);
		void sendUDPrefValues();

		bool isClicked(WORD currentState, WORD button);

		WORD m_PreviousButtonsState = 0;
		
		static constexpr int DEADZONEANVAL = 2000; // analog value for deadzone (for range: -32k ... 32k)

		// Auto mode refs
		float m_refPan = 0;
		float m_refTilt = 0;

		// data to send
		ClientUDPpacket m_PacketToSend{};

		// socket stuff
		static constexpr int UDPPORT = 12000;
		SOCKET m_udpSocket{};
};

