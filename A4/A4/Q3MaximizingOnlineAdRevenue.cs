using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            List<long> vaule = new List<long>();
            List<long> click = new List<long>();
            List<long> slot_values = new List<long>();
            long result=0;
            for(int i=0; i<adRevenue.Length; i++)
            {
                vaule.Add(adRevenue[i]);
            }
            for (int i = 0; i < averageDailyClick.Length; i++)
            {
                click.Add(averageDailyClick[i]);
            }
            vaule.Sort();
            click.Sort();
            for(int i = 0; i < click.Count; i++)
            {
                slot_values.Add(click[i] * vaule[i]);

             // Console.WriteLine(click[i]+" " + vaule[i]);
            }
            slot_values.Sort();

            for(int j =0;j<slotCount; j++)
            {
                result += slot_values[slot_values.Count - j-1];
            }
            return result;
        }
    }
}
