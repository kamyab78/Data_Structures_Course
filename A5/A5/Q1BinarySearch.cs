using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            long[] res = new long[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                res[i] = bainery(a, b[i]);
            }
            return res;
        }
        public static long bainery(long[] arraye, long index)
        {
            long kochik = 0;
            long bozorg = arraye.Length - 1;
            while (kochik <= bozorg)
            {
                long mid = (kochik + bozorg) / 2;

                if (index == arraye[mid])
                {
                    return mid;
                }
                if (index < arraye[mid])
                {
                    bozorg = mid - 1;
                }
                if (index > arraye[mid])
                {
                    kochik = mid + 1;
                }
            }
            return -1;
        }
    }
}
