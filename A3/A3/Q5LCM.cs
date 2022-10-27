using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long first = a;
            long second = b;

            long result=gdc(a, b);
            return lcm(first, second, result);
        }

        private long lcm(long first, long second, long result)
        {
            return ((first * second) / result);
        }

        private long gdc(long a, long b)
        {
            long x = a;
            long y = b;
            while (y != 0)
            {
                long r = x % y;
                x = y;
                y = r;
            }
            return x;
        }
    }
}
