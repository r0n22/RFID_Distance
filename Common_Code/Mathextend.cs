using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distancing_Algorithm.Code
{
    class Mathextend
    {
        /// <summary>
        /// Calculate the Std Devation
        /// </summary>
        /// <param name="values">List of values</param>
        /// <returns></returns>
        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
    }
}
