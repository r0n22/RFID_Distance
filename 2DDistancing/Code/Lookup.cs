using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace _2DDistancing.Code
{
    partial class LookupTable
    {
        public enum Axis
        {
            X,
            Y
        }
        public enum DistanceType { AVG, DFT };
        /// <summary>
        /// Add List of tags to the database that are assocated with this distance
        /// </summary>
        /// <param name="Distance">Distance of tags in cm</param>
        /// <param name="TagList">List of the tags</param>
        public void Add_Tags(int Distance, List<Tag> TagList, Axis axis)
        {
            
            List<LookupData> ConvertedData = TagList.ConvertAll(r => new LookupData(r, Distance,axis));

            this.LookupData.InsertAllOnSubmit(ConvertedData);

            this.SubmitChanges();
        }

        /// <summary>
        /// Deletes all lookup data
        /// </summary>
        public void DeleteLookup()
        {
            this.LookupData.DeleteAllOnSubmit(this.LookupData);

            this.SubmitChanges();
        }

       /* public List<Distancing.Distance> GetLookupTable_AVG(Axis axis)
        {
            List<Distancing.Distance> Output = new List<Distancing.Distance>();
            //this pulls a distinct list of the distance points in the DB
            foreach (int Dist in this.LookupData.Select(d => d.Distance).Distinct())
            {
                //decimal AvgI = (decimal)this.LookupData.Where(d => d.Distance.Equals(Dist)&& d.reciver.equals((int)axis)).Select(d => d.I).Average();
                //decimal AvgQ = (decimal)this.LookupData.Where(d => d.Distance.Equals(Dist)&& d.reciver.equals((int)axis)).Select(d => d.Q).Average();
                int count = this.LookupData.Where(d => d.Distance.Equals(Dist)).Count();
                Output.Add(new Distancing.Distance()
                {
                    Dist = Dist,
                    I = AvgI,
                    Q = AvgQ,
                    NumberofReads = count
                });
            }
            return Output;
        }
        */
        public List<Distancing.Distance> GetLookupTable(DistanceType Type,Axis axis)
        {
           /* if (Type.Equals(DistanceType.AVG))
                return GetLookupTable_AVG(axis);
            else
                return GetLookupTable_DFT(axis);
            */
            return new List<Distancing.Distance>();
        }

        /*public List<Distancing.Distance> GetLookupTable_DFT(Axis axis)
        {
            List<Distancing.Distance> Output = new List<Distancing.Distance>();
            //this pulls a distinct list of the distance points in the DB
            foreach (int Dist in this.LookupData.Select(d => d.Distance).Distinct())
            {
                decimal[] DFTI = DFT.Transform(this.LookupData.Where(d => d.Distance.Equals(Dist)&& d.reciver.equals((int)axis)).Select(d => d.I).ToArray());
                decimal[] DFTQ = DFT.Transform(this.LookupData.Where(d => d.Distance.Equals(Dist)&& d.reciver.equals((int)axis)).Select(d => d.Q).ToArray());
                int count = this.LookupData.Where(d => d.Distance.Equals(Dist)).Count();
                Output.Add(new Distancing.Distance()
                {
                    Dist = Dist,
                    I = DFTI[0],
                    Q = DFTQ[0],
                    NumberofReads = count
                });
            }
            return Output;
        }*/

        public void AddMeasurement(int Distance, int Avg_Distance, int DFT_Distance)
        {
            this.Distance_Measurements.InsertOnSubmit(new Distance_Measurements()
            {
                Exact_Measurements = Distance,
                Avg_Measurement = Avg_Distance,
                DFT_Measurement = DFT_Distance
            });
            this.SubmitChanges();
        }

        public double Get_Percetnage_Correct_Average(int Distance)
        {
            return (double)this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance) && d.Avg_Measurement.Equals(Distance)).Count() / this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance)).Count();
        }
        public double Get_Percetnage_Correct_DFT(int Distance)
        {
            return (double)this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance) && d.DFT_Measurement.Equals(Distance)).Count() / this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance)).Count();
        }

        public double Get_Average_Error_DFT(int Distance)
        {
            return (double)this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance)).Select(d => Math.Abs(d.Exact_Measurements - d.DFT_Measurement)).Average();
        }
        public double Get_Average_Error_AVG(int Distance)
        {
            return (double)this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance)).Select(d => Math.Abs(d.Exact_Measurements - d.Avg_Measurement)).Average();
        }
        public double Get_STD_Error_AVG(int Distance)
        {
            return Mathextend.CalculateStdDev(this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance)).Select(d => (double)Math.Abs(d.Exact_Measurements - d.Avg_Measurement)));
        }
        public double Get_STD_Error_DFT(int Distance)
        {
            
            return Mathextend.CalculateStdDev(this.Distance_Measurements.Where(d => d.Exact_Measurements.Equals(Distance)).Select(d => (double)Math.Abs(d.Exact_Measurements - d.DFT_Measurement)));
        }

        internal void AddTagAssocation()
        {
           List<TagAssocation> tags = new System.Collections.Generic.List<TagAssocation>();
           //Tag group 1
           tags.Add(new TagAssocation(){
               Tag_id=1,
               Tag_value="first"
           });
            tags.Add(new TagAssocation(){
               Tag_id=1,
               Tag_value="2nd"
           });
            //Tag group 2
            tags.Add(new TagAssocation(){
               Tag_id=2,
               Tag_value="fourth"
           });
            tags.Add(new TagAssocation(){
               Tag_id=2,
               Tag_value="third"
           });
            //Only add them if they have not been added yet
            if(this.TagAssocation.Count() < 4)
                this.TagAssocation.InsertAllOnSubmit(tags);
        }

        internal int Return_Tag_ID(string ID)
        {
            return this.TagAssocation.SingleOrDefault(t => t.Tag_value.Equals(ID)).Tag_id;
        }
    }
}
