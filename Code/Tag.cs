using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distancing_Algorithm.Code
{
    public class Tag
    {
        public int Q;
        public int I;

        public string ID;

        public Tag(byte[] payload)
        {
            //This is for bad packets that get through
            if (payload.Length < 22)
            {
                this.ID = "SHIT";
                this.Q = 0;
                this.I = 0;
                return;
            }
            this.Q = (int)(payload[3] >> 4) * 2;
            this.I = (int)(payload[3] & 0x0F) * 2;
            List<byte> IDbyte = new List<byte>();
            //THE MANUAL IS WRONG! DO NOT CHANGE! START 8 AND PAYLOAD 7 Look on page 19
            for (int i = 8; i < (int)payload[7]; i++)
            {
                IDbyte.Add(payload[i]);
            }

            // = payload.Skip(5).Take((int)payload[4]);


            this.ID = System.Text.Encoding.Default.GetString(IDbyte.ToArray());
        }

       
    }
}
