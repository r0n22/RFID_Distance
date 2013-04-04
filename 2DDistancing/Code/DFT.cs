using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AForge.Math;

namespace _2DDistancing.Code
{

    public class DFT
    {
        public static decimal[] Transform(int[] input)
        {
           /* int N = input.Length;
            Complex[] output = new Complex[N];
            
            Complex arg =Complex.ImaginaryOne * -2.0 * Math.PI / (double)N;
            for (int n = 0; n < N; n++)
            {
                output[n] = new Complex(0, 0);
                for (int k = 0; k < N; k++)
                    output[n] += input[k] * Complex.Exp( arg * (double)n * (double)k);
                outputdouble[n] = (decimal)output[n].Magnitude;
            }*/
              decimal[] outputdouble = new decimal[input.Length];
            Complex[] Data = new Complex[input.Length];
            for(int i = 0; i < input.Length;i++)
            {
                Data[i] = new Complex(input[i],0.0);
            }
            FourierTransform.DFT(Data, FourierTransform.Direction.Forward);
            for (int i = 0; i < input.Length; i++)
            {
                outputdouble[i] = (decimal)Data[i].Magnitude;
            }

            

            return outputdouble;
        }
    }

}
