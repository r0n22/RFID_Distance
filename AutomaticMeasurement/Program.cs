﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Distancing_Algorithm.Code;

namespace Distancing_Algorithm
{

    class Program
    {
        public static int Iterations = 50;
        public static int SleepTimer = 80;
        public static int Distance_Start = 5;
        public static int Distance_End = 75;
        public static int Distance_Interval = 5;
        public static int Configutation_num_reads = 100;
        static void Rebuild_Lookup_Table(LookupTable Lookup, ComPort Reader1)
        {
            List<Tag> Tags;
            //Delete data in lookup table
            Lookup.DeleteLookup();
            //Start Distance of the configuration
            int Distance = Distance_Start;
            Console.WriteLine("Please put tag at {0}cm then press enter", Distance);
            //Pause for setup
            Console.ReadKey(true);


            while (Distance <= Distance_End)
            {

                List<Tag> ListRead = new List<Tag>();
                while (ListRead.Count < Configutation_num_reads)
                {
                    //Seach for tags with RSSI
                    Tags = Inventory.StartTagInventory(Reader1);

                    //if more then 1 tag found and does not contain SHIT
                    //Then we read the tag and increment Read
                    if (Tags.Count > 0)
                        if (!Tags[0].ID.Contains("SHIT"))
                        {
                            ListRead.Add(Tags[0]);
                            Console.WriteLine("I:{0}, Q:{1}", Tags[0].I, Tags[0].Q);
                        }
                    //Sleep thread to get accurate measurements each time
                    //Has to be adjusted so we do not overflow the reader
                    // Console.WriteLine("Attempt:{0}",iter);
                    //System.Threading.Thread.Sleep(SleepTimer);
                }
                Lookup.Add_Tags(Distance, ListRead);
                Console.WriteLine("Added to DB!");
                Distance += Distance_Interval;
                Console.WriteLine("Please put tag at {0}cm then press enter", Distance);
                Console.ReadKey(true);

            }
        }

        static void Start_Reading(LookupTable Lookup, ComPort Reader1)
        {
            List<Tag> Tags;
            ConsoleKeyInfo key;
            Distancing Dist = new Distancing(LookupTable.DistanceType.DFT,Lookup);
            int iter = 0;
            while (true)
            {
                iter++;
                List<Tag> ListRead = new List<Tag>();
                int read = 0;
                while(ListRead.Count < Iterations)
				{
                    //Seach for tags with RSSI
                    Tags = Inventory.StartTagInventory(Reader1);

                    //if more then 1 tag found and does not contain SHIT
                    //Then we read the tag and increment Read
                    if (Tags.Count > 0)
                        if (!Tags[0].ID.Contains("SHIT"))
                        {
                            ListRead.Add(Tags[0]);
                            Console.WriteLine("I:{0}, Q:{1}", Tags[0].I, Tags[0].Q);
                        }
                    //Sleep thread to get accurate measurements each time
                    //Has to be adjusted so we do not overflow the reader
                    // Console.WriteLine("Attempt:{0}",iter);
                    //System.Threading.Thread.Sleep(SleepTimer);
                }
                //Calc Distances
                Console.WriteLine("Start Distancing:");
                List<int> Distances = Dist.Find_Distance(ListRead);
                //If Count is greater then 0 then it knows where to be
                if (Distances.Count > 0)
                    //If only one distance comes back then we know where we should be
                    if (Distances.Count == 1)
                        Console.WriteLine("Tag is at Distance of: {0}", Distances[0]);
                    else
                    {
                        //We have multiple places we could be.
                        Console.WriteLine("Multiple Distances:");
                        foreach (int Dis in Distances)
                            Console.WriteLine("Distance of: {0}", Dis);
                    }

                else
                    Console.WriteLine("Cannot Determine what the Distance is.");



                Console.WriteLine("Exit press 'x' Key");
                key = Console.ReadKey(true);
                if (key.KeyChar == 'x')
                {
                    //Initialization.PowerOFF(Reader1);
                    Reader1.Close();
                    Console.WriteLine("Antenna Powered OFF");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    //continue;
                    Console.WriteLine("Start Reading:");
                }
            }   
        }

		
        static void Main(string[] args)
        {
            LookupTable Lookup = new LookupTable("LookupTable.sdf");
            if (!Lookup.DatabaseExists())
            {
                Lookup.CreateDatabase();
            }
            
            //Create Com Port To talk to reader
            ComPort Reader1 = new ComPort("COM7");
            Reader1.Open();
            //Power on Antenna
            //Initialization.PowerOn(Reader1);
            //Console.WriteLine("Antenna Powered ON");
            Console.WriteLine("Do you want to Reconfigure the lookup Table?[Y/n]");
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            if (!(key.KeyChar == 'n'))
            {
                Rebuild_Lookup_Table(Lookup, Reader1);
            }
            Console.WriteLine("Do you want to start automatic error checking?[Y/n]");
            key = Console.ReadKey(true);

            if (!(key.KeyChar == 'n'))
            {
                Start_Automatic_Error_Checking(Lookup, Reader1);
            }

            Console.WriteLine("Start Reading:");
            Start_Reading(Lookup, Reader1);
        }

        private static void Start_Automatic_Error_Checking(LookupTable Lookup, ComPort Reader1)
        {
            int Number_of_iterations = 20;
            List<Tag> Tags;
            //Start Distance of the configuration
            int Distance = Distance_Start;
            Console.WriteLine("Initalizting Lookup Tables");
            Distancing AVG = new Distancing(LookupTable.DistanceType.AVG, Lookup);
            Distancing DFT = new Distancing(LookupTable.DistanceType.DFT, Lookup);
            
           
            while (Distance <= Distance_End)
            {
                Console.WriteLine("Please put tag at {0}cm then press enter", Distance);
                //Pause for setup
                Console.ReadKey(true);
                //Number of times to try the reading
                for (int i = 0; i < Number_of_iterations; i++)
                {
                    List<Tag> ListRead = new List<Tag>();
                    while (ListRead.Count < Configutation_num_reads)
                    {
                        //Seach for tags with RSSI
                        Tags = Inventory.StartTagInventory(Reader1);

                        //if more then 1 tag found and does not contain SHIT
                        //Then we read the tag and increment Read
                        if (Tags.Count > 0)
                            if (!Tags[0].ID.Contains("SHIT"))
                            {
                                ListRead.Add(Tags[0]);
                                Console.WriteLine("I:{0}, Q:{1}", Tags[0].I, Tags[0].Q);
                            }
                        //Sleep thread to get accurate measurements each time
                        //Has to be adjusted so we do not overflow the reader
                        // Console.WriteLine("Attempt:{0}",iter);
                        //System.Threading.Thread.Sleep(SleepTimer);
                    }

                    List<int> Distance_Avg = AVG.Find_Distance(ListRead);
                    List<int> Distance_DFT = DFT.Find_Distance(ListRead);
                    if (Distance_Avg.Count == 1 && Distance_DFT.Count == 1)
                    {
                        Lookup.AddMeasurement(Distance, Distance_Avg.First(), Distance_DFT.First());
                        Console.WriteLine("Added Results to the DB iteration:{0} for Distance:{1}", Iterations, Distance);
                    }
                    else
                    {
                        Console.WriteLine("One of the methods returned more then one result");
                    }
               }
                
                //Increment Distance
                Distance += Distance_Interval;
                
            }
            Distance = Distance_Start;
            Console.WriteLine("PRINTING RESULTS:");
            while (Distance <= Distance_End)
            {
                Console.WriteLine("Distance:{0}", Distance);
                Console.WriteLine("Avg Algorithm (Correct,Avg Error,Error Std) ({0:0.0%},{1},{2})", 
                    Lookup.Get_Percetnage_Correct_Average(Distance), 
                    Lookup.Get_Average_Error_AVG(Distance), 
                    Lookup.Get_STD_Error_AVG(Distance));
                Console.WriteLine("DFT Algorithm (Correct,Avg Error,Error Std) ({0:0.0%},{1},{2})",
                    Lookup.Get_Percetnage_Correct_DFT(Distance),
                    Lookup.Get_Average_Error_DFT(Distance),
                    Lookup.Get_STD_Error_DFT(Distance));
                Distance += Distance_Interval;
            }
        }
    }
}
