using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            long[] array = new long[n + 1];

            array[0] = 0;
            array[1] = 0;
            long kochik;
            for (long i = 2; i < n + 1; i++)
            {
                kochik = array[i - 1] + 1;

                if (i % 2 == 0 /*&& array[i / 2] + 1 <= kochik*/)
                    kochik = Math.Min(kochik, array[i / 2] + 1);

                if (i % 3 == 0 /*&& array[i / 3] + 1 <= kochik*/)
                    kochik = Math.Min(kochik, array[i / 3] + 1);

                array[i] = kochik;

            }
            // Console.WriteLine(array[n+1]);
            List<long> result = new List<long>();
            // long[] result = new long[array[n] + 1];
            for (long j = 0; j < array[array.Length-1] ; j++)
            {
                long res = 0;
                result.Add(n);
                long dow = array[n / 2];
                long se = array[n / 3];
                long yek = array[n - 1];

                if (n % 2 == 0 && n % 3 == 0)
                {
                    res = Math.Min(yek, Math.Min(dow, se));
                    if (res == se)
                        n = n / 3;
                    else if (res == dow)
                        n = n / 2;
                    else
                        n = n - 1;
                    continue;
                }
                if (n % 2 == 0 && n % 3 != 0)
                {
                    res = Math.Min(dow, yek);
                    if (res == dow)
                        n = n / 2;

                    else
                        n = n - 1;
                    continue;
                }
                if (n % 2 != 0 && n % 3 != 0)
                {
                    n = n - 1;
                    continue;
                }

                if (n % 2 != 0 && n % 3 == 0)
                {
                    res = Math.Min(yek, se);
                    if (res == se)
                        n = n / 3;
                    else
                        n = n - 1;
                    continue;
                }

            }
            result.Add(1);
            result.Remove(0);
            result.Reverse();
            return result.ToArray();

        }
    }
}
