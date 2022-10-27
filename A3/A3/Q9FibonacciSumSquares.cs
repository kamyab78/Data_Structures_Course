using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<int> fib = new List<int>();
            fib.Add(0);
            fib.Add(1);
          
            while (true)
            {
                fib.Add((fib[fib.Count - 1] + fib[fib.Count - 2])%10);

                if(fib[fib.Count-1]==1 && fib[fib.Count - 2] == 0)
                {
                    break;

                }
         
            }
            Console.WriteLine((int)n % (fib.Count - 2));

            return (fib[(int)(n % (fib.Count - 2))] * (fib[(int)(n % (fib.Count - 2))] + (fib[((int)(n % (fib.Count - 2)) - 1)])))%10;
        }
    }
}
