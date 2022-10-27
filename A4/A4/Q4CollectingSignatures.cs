using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            Class_4[] arrey = new Class_4[startTimes.Length];
            for (int i = 0; i < startTimes.Length; i++)
            {
                arrey[i] = new Class_4(startTimes[i], endTimes[i]);

            }
            arrey = arrey.ToList().OrderBy(Element => Element.start).ToArray();
            arrey = arrey.ToList().OrderBy(Element => Element.end).ToArray();

            long index = 0;
            long last = 0;
            while (index < arrey.Length)
            {
                long akhar = arrey[index].end;
                while (index < arrey.Length && arrey[index].start <= akhar)
                {
                    if (arrey[index].start <= akhar && akhar <= arrey[index].end)
                        index++;
                }
                     last++;
            }
            return last;

        }
    }
}
