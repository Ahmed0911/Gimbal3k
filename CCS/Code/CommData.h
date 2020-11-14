/*
 * CommData.h
 *
 *  Created on: Jan 10, 2016
 *      Author: Ivan
 */

#ifndef COMMDATA_H_
#define COMMDATA_H_

#include <stdint.h>

struct SGimbal3kData
{
    uint32_t LoopCounter;
    uint16_t Position1;
    uint16_t Position2;

    float AccX; // [m/s^2]
    float AccY; // [m/s^2]
    float AccZ; // [m/s^2]

    // GPS
    double HomeLongitude; // [deg]
    double HomeLatitude; // [deg]
};

// Ethernet packets
// data[0] = 0x42; // magic codes
// data[1] = 0x24; // magic codes
// data[2] = TYPE; // [0x10 - PING, 0x20 - DATA...]
// data[3] = data....
#endif /* COMMDATA_H_ */
