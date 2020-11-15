using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Gimbal3kWInClient
{ 
   public unsafe struct SGimbal3kData
    {
        public UInt32 LoopCounter;
        public UInt32 ActiveMode;
        public UInt16 PositionPanEncoCNT;
        public UInt16 PositionTiltEncoCNT;
        
        public float PositionPanDeg;
        public float PositionTiltDeg;

        public float AccX; // [m/s^2]
        public float AccY; // [m/s^2]
        public float AccZ; // [m/s^2]

        // GPS
        public double HomeLongitude; // [deg]
        public double HomeLatitude; // [deg]
    }

    public unsafe struct SGimbal3kCommand
    {
        public UInt32 Command; // 0 - Disabled, 1 - Manual Ctrl
        public float RefPan; // [-1...+1]
        public float RefTilt; // [-1...+1]
    }

    class Comm
    {
        public static byte[] GetBytes(object str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static object FromBytes(byte[] arr, object str)
        {
            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}
