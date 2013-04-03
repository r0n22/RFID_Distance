using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distancing_Algorithm.Code
{
    public static class Constants
    {
        public static class ANTPower
        {
            public static byte SendID
            {
                get
                {
                    return 0x18;
                }
            }

            public static byte RecieveID
            {
                get
                {
                    return 0x19;
                }
            }

            public static class Power
            {
                public static byte OFF
                {
                    get { return 0x00; }
                }
                public static byte ON
                {
                    get { return 0xFF; }
                }
            }   
        }

        public static class InventoryRSSI
        {
            public static byte SendID
            {
                get
                {
                    return 0x43;
                }
            }

            public static byte RecieveID
            {
                get
                {
                    return 0x44;
                }
            }

            public static class Type
            {
                public static byte[] Start
                {
                    get { return new byte[] { 0x01, 0xCD }; }
                }
                public static byte[] Next
                {
                    get { return new byte[] { 0x02, 0xCD }; }
                }
            }
        }
        public static class Error
        {
            public static byte NoError
            {
                get { return 0x00; }
            }

            public static byte Timeout
            {
                get { return 0xFF; }
            }
        }
    }

    

    public class Helpers
    {
        public static bool CheckPacket(byte[] Packet)
        {
            return Packet[1] == Packet.Count();
        }
    }
}
