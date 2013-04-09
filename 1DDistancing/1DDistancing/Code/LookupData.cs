using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DDistancing.Code
{
    public partial class LookupData
    {
        public LookupData(Tag input, int Distance):this()
        {
            this.Distance = Distance;
            this.I = input.I;
            this.Q = input.Q;
        }

    }
}
