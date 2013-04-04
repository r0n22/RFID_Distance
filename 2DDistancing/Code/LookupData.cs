using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DDistancing.Code
{
    public partial class LookupData
    {
        

        public LookupData(Tag input, int Distance):this()
        {
            this.Distance = Distance;
            this.I = input.I;
            this.Q = input.Q;
        }

        public LookupData(Tag r, int Distance_2, LookupTable.Axis axis):this(r,Distance_2)
        {
            
            this.Reciver = (int)axis;
        }

    }
}
