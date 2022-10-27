using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long res= knapsack(W, goldBars, goldBars.Length);
            
            return res;
        }

        private long knapsack(long w, long[] goldBars, int length)
        {
            long[,] res = new long[length + 1, w + 1];
            for (int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= w; j++)
                {
                    if (i == 0 || j == 0)
                        res[i, j] = 0;
                    else if (goldBars[i - 1] <= j)
                        res[i, j] = Math.Max(res[i - 1, j], goldBars[i - 1] + res[i - 1, j - goldBars[i - 1]]);
                    else
                        res[i, j] = res[i - 1, j];
                }
            }

            return res[length, w];

        }
    }
}
