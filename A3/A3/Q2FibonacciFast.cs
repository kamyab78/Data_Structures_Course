using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            if (n == 0)
            {
                return 0;
            }
            int[] fib = new int[n+1];
            fib[0] = 0;
            fib[1] = 1;

            for(int i = 2; i <=n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            if (n == 1)
            {
                fib[n ] = 1;
            }
       
            return fib[n];
        }


    }
}
