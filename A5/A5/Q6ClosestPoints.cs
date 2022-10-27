using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] xPoints, long[] yPoints)
        {
            List<Tuple<long, long>> list = new List<Tuple<long, long>>();
            for (int i = 0; i < xPoints.Length; i++)
            {
                Tuple<long, long> noghte = new Tuple<long, long>(xPoints[i], yPoints[i]);
                list.Add(noghte);
            }
            list = list.OrderBy(x => x.Item1).ToList();
            long first = 0;
            long end = list.Count;
            return partion(list, first, end);
            //return 2.2;
        }

            private double partion(List<Tuple<long, long>> list, long first, long end)
            {
                
                if (end - first == 2)
                {
                   return Math.Round( cal(list[(int)first], list[(int)first + 1]) , 4) ;
                }
                if (end - first == 3)
                {
                   return Math.Round( cal_1(list[(int)first], list[(int)first + 1], list[(int)first + 2]) , 4);
                }

                long mid = (first + end) / 2;
                long mid_1 = (first + mid) / 2;
                long mid_2 = (mid + end) / 2;
                double yek = partion(list, first, mid);
                double dow = partion(list, mid, end);
                double se = partion(list, mid_1, mid_2);
                double compare = Math.Min(yek, dow);
                return Math.Min(compare, se);
            }

            private double cal_1(Tuple<long, long> tuple1, Tuple<long, long> tuple2, Tuple<long, long> tuple3)
            {
                double yek = Math.Sqrt(((tuple1.Item1 - tuple2.Item1) * (tuple1.Item1 - tuple2.Item1)) + ((tuple1.Item2 - tuple2.Item2) * (tuple1.Item2 - tuple2.Item2)));

                double two = Math.Sqrt(((tuple1.Item1 - tuple3.Item1) * (tuple1.Item1 - tuple3.Item1)) + ((tuple1.Item2 - tuple3.Item2) * (tuple1.Item2 - tuple3.Item2)));

                double se = Math.Sqrt(((tuple3.Item1 - tuple2.Item1) * (tuple3.Item1 - tuple2.Item1)) + ((tuple3.Item2 - tuple2.Item2) * (tuple3.Item2 - tuple2.Item2)));
                double compare = Math.Min(yek, two);
                return Math.Min(compare, se);
            }


            private double cal(Tuple<long, long> tuple1, Tuple<long, long> tuple2)
            {
                return Math.Sqrt(((tuple1.Item1 - tuple2.Item1) * (tuple1.Item1 - tuple2.Item1)) + ((tuple1.Item2 - tuple2.Item2) * (tuple1.Item2 - tuple2.Item2)));
            }
        }
    }
