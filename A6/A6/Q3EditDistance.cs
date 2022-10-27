using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            return editdistance(str1, str2, str1.Length, str2.Length);
        }

        private long editdistance(string str1, string str2, int length1, int length2)
        {
            long[,] array = new long[length1 + 1, length2 + 1];
            for (int i = 0; i <= length1; i++)
            {
                for (int j = 0; j <= length2; j++)
                {
                    if (i == 0)
                        array[i, j] = j;
                    else if (j == 0)
                        array[i, j] = i;

                    else if (str1[i - 1] == str2[j - 1])
                        array[i, j] = array[i - 1, j - 1];
                    else
                        array[i, j] = 1 + min(array[i - 1, j - 1]
                , array[i, j - 1], array[i - 1, j]);

                }
            }
            return array[length1, length2];
        }

        private long min(long v1, long v2, long v3)
        {
            if (v1 <= v2 && v1 <= v3)
                return v1;
            if (v2 <= v1 && v2 <= v3)
                return v2;
            else return v3;
        }
    }
}
