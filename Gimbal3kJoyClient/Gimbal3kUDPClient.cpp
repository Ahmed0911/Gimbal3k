// JoystickVehicleUDPController.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "JoyController.h"
#include <iostream>
#include <thread>
#include <chrono>

int main()
{
    std::cout << "Gimbal 3k Joystick Client V1.0!\n";

    JoyController joy("192.168.0.101");

    while (1)
    {
        joy.execute();

        // sleed until next iteration
        std::this_thread::sleep_for(std::chrono::milliseconds(10));
    }
}
