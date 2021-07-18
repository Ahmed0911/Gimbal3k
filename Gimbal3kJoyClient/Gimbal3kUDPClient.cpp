// JoystickVehicleUDPController.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "JoyController.h"
#include <iostream>
#include <thread>
#include <chrono>

int main()
{
    std::cout << "Gimbal 3k Joystick Client V1.1!\n";

    JoyController joy("192.168.5.231");

    while (1)
    {
        joy.execute();

        // sleed until next iteration
        std::this_thread::sleep_for(std::chrono::milliseconds(10));
    }
}
