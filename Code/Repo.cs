﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distancing_Algorithm.Code
{
    public partial class LookupTable
    {
        public enum DistanceType {AVG, DFT};
        /// <summary>
        /// Add List of tags to the database that are assocated with this distance
        /// </summary>
        /// <param name="Distance">Distance of tags in cm</param>
        /// <param name="TagList">List of the tags</param>
        public void Add_Tags(int Distance, List<Tag> TagList)
        {
            List<LookupData> ConvertedData = TagList.ConvertAll( r => new LookupData(r,Distance));

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

        public List<Distancing.Distance> GetLookupTable_AVG()
        {
            List<Distancing.Distance> Output = new List<Distancing.Distance>();
            //this pulls a distinct list of the distance points in the DB
            foreach (int Dist in this.LookupData.Select(d => d.Distance).Distinct())
            {
                decimal AvgI = (decimal)this.LookupData.Where(d => d.Distance.Equals(Dist)).Select(d => d.I).Average();
                decimal AvgQ = (decimal)this.LookupData.Where(d => d.Distance.Equals(Dist)).Select(d => d.Q).Average();
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

        public List<Distancing.Distance> GetLookupTable(DistanceType Type)
        {
            if(Type.Equals(DistanceType.AVG))
                return GetLookupTable_AVG();
            else
                return GetLookupTable_DFT();
        }

        public List<Distancing.Distance> GetLookupTable_DFT()
        {
            List<Distancing.Distance> Output = new List<Distancing.Distance>();
            //this pulls a distinct list of the distance points in the DB
            foreach (int Dist in this.LookupData.Select(d => d.Distance).Distinct())
            {
                decimal[] DFTI = DFT.Transform(this.LookupData.Where(d => d.Distance.Equals(Dist)).Select(d => d.I).ToArray());
                decimal[] DFTQ = DFT.Transform(this.LookupData.Where(d => d.Distance.Equals(Dist)).Select(d => d.Q).ToArray());
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
        }
    }
}
