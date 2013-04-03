using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Distancing_Algorithm.Code;

namespace Distancing_Algorithm.Code
{
    public class Distancing
    {
        LookupTable.DistanceType Type;
        /*/// <summary>
        /// Using RSSI and a linear ap
        /// </summary>
        private static double Tag_Loss = 0;
        private static double Distance_loss = .01;
        private static double wavelength = .3246;
        private static double constant = 4*3.14*10;
        private static double TransvicerAntennaGain = 8;
        private static double TagAntennaGain = 0;


        public static double Distance(double Q, double I)
        {
            double RSSI = Math.Sqrt((Q*Q)+(I*I));
          //  return  (constant*(-((RSSI - Tag_Loss)+2*TransvicerAntennaGain*TagAntennaGain))/40);
            return RSSI;
        }*/

        //const decimal thresholdQ = 4M;
        //const decimal thresholdI = thresholdQ/3;
        const decimal NumStdevations = 2;
        List<Distance> LookupDistances;
        /// <summary>
        /// Class for Distancing
        /// </summary>
        public class Distance
        {
            public int Dist { get; set; }
            public decimal Q { get; set; }
            public decimal I { get; set; }
            public int NumberofReads { get; set; }
        }

        /// <summary>
        /// Constructor with default Lookup Table
        /// </summary>
        public Distancing(LookupTable.DistanceType Type, LookupTable Lookup)
        {
            LookupDistances = Lookup.GetLookupTable(Type);
            this.Type = Type;
           
        }

        

        /// <summary>
        /// Returns a number of distances that we think the tag is at.
        /// </summary>
        /// <param name="Read_Values">List of the tags that were read.</param>
        /// <returns>0,1,many distances</returns>
        private List<int> Find_Distance_Avg(List<Tag> Read_Values)
        {
            //List of distances it could be
            List<Distance> Distance = new List<Distance>();
            //find average of Q and I
            decimal AvgQ = Read_Values.Average(t => (decimal)t.Q);
            decimal AvgI = Read_Values.Average(t => (decimal)t.I);
            decimal StdQ = (decimal)Mathextend.CalculateStdDev(Read_Values.Select(t => (double)t.Q));
            decimal StdI = (decimal)Mathextend.CalculateStdDev(Read_Values.Select(t => (double)t.I));
            Console.WriteLine("AvgI:{0}, AvgQ:{1}", AvgI, AvgQ);
            Console.WriteLine("StdI:{0}, stdQ:{1}", StdI, StdQ);
            //Find The Lookup table that the average Q is within the threshold of the Distance
            //Distance.AddRange(LookupTable.Where(r => Math.Abs(r.Q - AvgQ) < thresholdQ && Math.Abs(r.I - AvgI) < thresholdI).Select(r => r.Dist));
            IEnumerable<Distance> temp = LookupDistances.Where(r => Math.Abs(r.Q - AvgQ) < (StdQ*NumStdevations));
            Distance = temp.ToList();
            List<int> DistanceOut = new List<int>();

            if (Distance.Count > 1)
            {
                List<Distance> Distance2 = new List<Distance>();

                IEnumerable<Distance> temp2 = Distance.Where(r => Math.Abs(r.I - AvgI) < (StdI * NumStdevations));
                Distance2 = temp2.ToList();
                //List<decimal> tempI = new List<decimal>();
                ////decimal [] tempI= new decimal[Distance.Count()];
                //for (int i = 0; i < Distance.Count(); i++)
                //{
                //    tempI.AddRange(LookupTable.Where(r => Distance[i] == r.Dist).Select(r => r.I));
                //}
                //decimal best = 100;
                //foreach (decimal I in tempI)
                //{
                //    if (Math.Abs(I - AvgI) < Math.Abs(best - AvgI))
                //    {
                //        best = I;
                //    }
                //}
                //Distance2.AddRange(LookupTable.Where(r => best == r.I).Select(r => r.Dist));

                //return Distance2;
               

                if (Distance2.Count > 1)
                {
                    List<decimal> tempCount = new List<decimal>();
                    //decimal [] tempI= new decimal[Distance.Count()];
                    //for (int i = 0; i < Distance2.Count(); i++)
                    //{
                    //    tempCount.AddRange(Distance2.Where(r => Distance2[i] == r.Dist).Select(r => r.I));
                    //}
                    decimal best = 100;
                    foreach (Distance reads in Distance2)
                    {
                        if (Math.Abs(reads.NumberofReads - Read_Values.Count) < Math.Abs(best - Read_Values.Count))
                        {
                            best = reads.NumberofReads;
                        }
                    }
                    DistanceOut.Add(Distance2.Where(r => best == r.NumberofReads).Select(r => r.Dist).FirstOrDefault());

                    return DistanceOut;
                }
                else if(Distance2.Count==1)
                    DistanceOut.Add(Distance2[0].Dist);
                return DistanceOut;
            }
            else if (Distance.Count == 1)
                DistanceOut.Add(Distance[0].Dist);
            //This will be able to return 0,1,many returns
            return DistanceOut;
        }
        public List<int> Find_Distance(List<Tag> Read_Values)
        {
            if (this.Type.Equals(LookupTable.DistanceType.AVG))
                return Find_Distance_Avg(Read_Values);
            else
                return Find_Distance_DFT(Read_Values);
        }
        

        /// <summary>
        /// Returns a number of distances that we think the tag is at.
        /// </summary>
        /// <param name="Read_Values">List of the tags that were read.</param>
        /// <returns>0,1,many distances</returns>
        private List<int> Find_Distance_DFT(List<Tag> Read_Values)
        {
            List<int> Distances = new List<int>();
            //List of distances it could be
            Distance Distance = new Distance();
            double LowestMSE = 99999999;
            //find average of Q and I
            decimal[] DFTQ = DFT.Transform(Read_Values.Select(t => t.Q).ToArray());
            decimal[] DFTI = DFT.Transform(Read_Values.Select(t => t.I).ToArray());

            foreach (Distance d in LookupDistances)
            {
                double MSE = Math.Pow((double)(d.I - DFTI[0]), 2) + Math.Pow((double)(d.Q - DFTQ[0]), 2);
                /*Console.WriteLine("Distance is {0}", d.Dist);
                Console.WriteLine("(LookupI, I)({0}，{1})", d.I, DFTI[0]);
                Console.WriteLine("(LookupQ, Q)({0}，{1})", d.Q, DFTQ[0]);*/
                if (MSE < LowestMSE)
                {
                    Distance = d;
                    LowestMSE = MSE;
                }
            }
            Distances.Add(Distance.Dist);
            //This will be able to return 0,1,many returns
            return Distances;
        }

    }
}
