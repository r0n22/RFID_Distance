using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distancing_Algorithm.Code
{
    class Distancing
    {
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

        const decimal thresholdQ = 4M;
        const decimal thresholdI = thresholdQ/3;
        List<Distance> LookupTable;
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
        public Distancing()
        {
            LookupTable = new List<Distance>();

            LookupTable.Add(new Distance() { Dist = 5, I = 7M, Q = 25.5M, NumberofReads = 8 });
            LookupTable.Add(new Distance() { Dist = 10, I = 28M, Q = 25.5652173913043M, NumberofReads = 46 });
            LookupTable.Add(new Distance() { Dist = 15, I = 17.5555555555556M, Q = 21.8888888888889M, NumberofReads = 18 });
            LookupTable.Add(new Distance() { Dist = 20, I = 27.9583333333333M, Q = 22.6666666666667M, NumberofReads = 48 });
            LookupTable.Add(new Distance() { Dist = 25, I = 11.7777777777778M, Q = 20.8888888888889M, NumberofReads = 9 });
            LookupTable.Add(new Distance() { Dist = 30, I = 23.531914893617M, Q = 23.7872340425532M, NumberofReads = 47 });
            LookupTable.Add(new Distance() { Dist = 35, I = 24.8510638297872M, Q = 18.4255319148936M, NumberofReads = 47 });
            LookupTable.Add(new Distance() { Dist = 40, I = 9.2M, Q = 22M, NumberofReads = 15 });
            LookupTable.Add(new Distance() { Dist = 45, I = 23.0666666666667M, Q = 23.9111111111111M, NumberofReads = 45 });
            LookupTable.Add(new Distance() { Dist = 50, I = 23.1363636363636M, Q = 9.63636363636364M, NumberofReads = 44 });
            LookupTable.Add(new Distance() { Dist = 55, I = 19.4285714285714M, Q = 23.4285714285714M, NumberofReads = 42 });
            LookupTable.Add(new Distance() { Dist = 60, I = 25.2M, Q = 22.2M, NumberofReads = 30 });
            LookupTable.Add(new Distance() { Dist = 65, I = 0M, Q = 0M, NumberofReads = 1 });
            LookupTable.Add(new Distance() { Dist = 70, I = 25.7333333333333M, Q = 21.9555555555556M, NumberofReads = 45 });
            LookupTable.Add(new Distance() { Dist = 75, I = 19.4545454545455M, Q = 5.81818181818182M, NumberofReads = 11 });
            LookupTable.Add(new Distance() { Dist = 80, I = 19.6666666666667M, Q = 22.3333333333333M, NumberofReads = 12 });
            LookupTable.Add(new Distance() { Dist = 85, I = 23.6923076923077M, Q = 13.4871794871795M, NumberofReads = 39 });
            LookupTable.Add(new Distance() { Dist = 90, I = 0M, Q = 0M, NumberofReads = 1 });
            LookupTable.Add(new Distance() { Dist = 95, I = 18M, Q = 17.3333333333333M, NumberofReads = 12 });
            LookupTable.Add(new Distance() { Dist = 100, I = 18.8095238095238M, Q = 5.52380952380952M, NumberofReads = 42 });
            //LookupTable.Add(new Distance() { Dist = 105, I = 0M, Q = 0M, NumberofReads = 1 });
            //LookupTable.Add(new Distance() { Dist = 110, I = 21.1707317073171M, Q = 20.5365853658537M, NumberofReads = 41 });
            //LookupTable.Add(new Distance() { Dist = 115, I = 19.8823529411765M, Q = 10.7647058823529M, NumberofReads = 34 });
            //LookupTable.Add(new Distance() { Dist = 120, I = 17.5555555555556M, Q = 19.2777777777778M, NumberofReads = 36 });
            //LookupTable.Add(new Distance() { Dist = 125, I = 20.7368421052632M, Q = 19.7894736842105M, NumberofReads = 38 });
            //LookupTable.Add(new Distance() { Dist = 130, I = 17.0588235294118M, Q = 17.1764705882353M, NumberofReads = 17 });
            //LookupTable.Add(new Distance() { Dist = 135, I = 24.0444444444444M, Q = 20.4M, NumberofReads = 45 });
            //LookupTable.Add(new Distance() { Dist = 140, I = 22.4375M, Q = 8.9375M, NumberofReads = 32 });
            //LookupTable.Add(new Distance() { Dist = 145, I = 19.0714285714286M, Q = 22.7857142857143M, NumberofReads = 28 });
            //LookupTable.Add(new Distance() { Dist = 150, I = 23.8048780487805M, Q = 8.58536585365854M, NumberofReads = 41 });
            //LookupTable.Add(new Distance() { Dist = 155, I = 17.2M, Q = 21.6M, NumberofReads = 30 });
            //LookupTable.Add(new Distance() { Dist = 160, I = 24.6923076923077M, Q = 21.7692307692308M, NumberofReads = 26 });
            //LookupTable.Add(new Distance() { Dist = 165, I = 10.2857142857143M, Q = 15.7142857142857M, NumberofReads = 7 });
            //LookupTable.Add(new Distance() { Dist = 170, I = 23.8666666666667M, Q = 14.7333333333333M, NumberofReads = 30 });
            //LookupTable.Add(new Distance() { Dist = 175, I = 0M, Q = 0M, NumberofReads = 1 });
            //LookupTable.Add(new Distance() { Dist = 180, I = 19.7333333333333M, Q = 18.1333333333333M, NumberofReads = 15 });
            //LookupTable.Add(new Distance() { Dist = 185, I = 9.2M, Q = 18M, NumberofReads = 5 });

            //Add in all Distance values here;
        }

        /// <summary>
        /// Returns a number of distances that we think the tag is at.
        /// </summary>
        /// <param name="Read_Values">List of the tags that were read.</param>
        /// <returns>0,1,many distances</returns>
        public List<int> Find_Distance(List<Tag> Read_Values)
        {
            //List of distances it could be
            List<Distance> Distance = new List<Distance>();
            //find average of Q and I
            decimal AvgQ = Read_Values.Average(t => (decimal)t.Q);
            decimal AvgI = Read_Values.Average(t => (decimal)t.I);

            Console.WriteLine("AvgI:{0}, AvgQ:{1}", AvgI, AvgQ);

            //Find The Lookup table that the average Q is within the threshold of the Distance
            //Distance.AddRange(LookupTable.Where(r => Math.Abs(r.Q - AvgQ) < thresholdQ && Math.Abs(r.I - AvgI) < thresholdI).Select(r => r.Dist));
            IEnumerable<Distance> temp = LookupTable.Where(r => Math.Abs(r.Q - AvgQ) < thresholdQ);
            Distance = temp.ToList();
            List<int> DistanceOut = new List<int>();

            if (Distance.Count > 1)
            {
                List<Distance> Distance2 = new List<Distance>();

                IEnumerable<Distance> temp2 = Distance.Where(r => Math.Abs(r.I - AvgI) < thresholdI);
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
                    DistanceOut.AddRange(Distance2.Where(r => best == r.NumberofReads).Select(r => r.Dist));

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

    }
}
