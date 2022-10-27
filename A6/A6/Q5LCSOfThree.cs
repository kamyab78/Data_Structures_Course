using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            return calculate(seq1, seq2, seq3, seq1.Length, seq2.Length, seq3.Length);
        }

        private long calculate(long[] seq1, long[] seq2, long[] seq3, int length1, int length2, int length3)
        {
            long[,,] res = new long[length1 + 1, length2 + 1, length3 + 1];
            for(int i=0; i <= length1; i++)
            {
                for(int j = 0; j <= length2; j++)
                {
                    for(int k = 0; k <= length3; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            res[i, j, k] = 0;
                        else if (seq1[i - 1] == seq2[j - 1] && seq1[i - 1] == seq3[k - 1])
                            res[i, j, k] = res[i - 1, j - 1, k - 1] + 1;
                        else
                            res[i, j, k] = Math.Max(res[i, j, k - 1],Math.Max( res[i, j - 1, k], res[i - 1, j, k]));
                    }
                }
            }
            return res[length1, length2, length3];
        }
    }
}
