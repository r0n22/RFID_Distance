using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DDistancing.Code
{
    class Initialization
    {
        public static void PowerOn(ComPort port)
        {
            port.SendCommand(Constants.ANTPower.SendID, Constants.ANTPower.Power.ON);
            port.WaitInventoryPacket();
            byte[] Back = port.ReadPacket();
            if (!(Back[0] == Constants.ANTPower.RecieveID && Back[2] == Constants.Error.NoError))
                throw new Exception("Error Turning on the Antenna!");

        }
        public static void PowerOFF(ComPort port)
        {
            port.SendCommand(Constants.ANTPower.SendID, Constants.ANTPower.Power.OFF);
            byte[] Back = port.ReadPacket();
            if (!(Back[0] == Constants.ANTPower.RecieveID && Back[2] == Constants.Error.NoError))
                throw new Exception("Error Turning OFF the Antenna!");
        }

    }
}
