using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            return calculate(seq1, seq2, seq1.Length, seq2.Length);
        }

        private long calculate(long[] seq1, long[] seq2, int length1, int length2)
        {
            long[,] res = new long[length1 + 1, length2 + 1];
            for(int i=0; i <=length1; i++)
            {
                for(int j=0; j <= length2; j++)
                {
                    if (i == 0 || j == 0)
                        res[i, j] = 0;
                    else if (seq1[i - 1] == seq2[j - 1])
                        res[i, j] = res[i - 1, j - 1] + 1;
                    else
                       res[i,j]= Math.Max(res[i - 1, j], res[i, j - 1]);
                }
            }
            return res[length1, length2];
        }
    }
}
