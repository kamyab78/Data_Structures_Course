using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            List<Tuple<long, int, int>> list = new List<Tuple<long, int, int>>();
            for (int i = 0; i < startSegments.Length; i++)
            {
                Tuple<long, int, int> start = new Tuple<long, int, int>(startSegments[i], 0, i);
                list.Add(start);
            }
            for (int j = 0; j < endSegment.Length; j++)
            {
                Tuple<long, int, int> end = new Tuple<long, int, int>(endSegment[j], 2, j);
                list.Add(end);
            }
            for (int k = 0; k < points.Length; k++)
            {
                Tuple<long, int, int> point = new Tuple<long, int, int>(points[k], 1, k);
                list.Add(point);
            }

            list = list.OrderBy(x => x.Item2).OrderBy(y => y.Item1).ToList();

            long[] res = new long[points.Length];
            long p = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item2 == 0)
                {
                    p++;
                }
                if (list[i].Item2 == 1)
                {
                    res[list[i].Item3] = p;
                }
                if (list[i].Item2 == 2)
                {
                    p--;
                }
            }

            return res;
        }
    }
}
