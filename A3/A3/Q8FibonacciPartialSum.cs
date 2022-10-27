using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long jam = 0;
            long baghi = 0;
            long baghi_big = 0;
            if (a > b)
            {
                long temp = a;
                a = b;
                b = temp;
            }
            List<int> fib = new List<int>();
            fib.Add(0);
            fib.Add(1);
            int index = 0;
            while (true)
            {
                fib.Add((fib[fib.Count - 1] + fib[fib.Count - 2])%10);
                if (fib[fib.Count - 1] == 1 && fib[fib.Count - 2] == 0)
                {
                    index++;
                }
                if (index == 1)
                {
                    break;
                }


            }
            Console.WriteLine(fib.Count - 2);
            long taghsim = (a-1) / (fib.Count - 2);
            long baghimande = (a-1) % (fib.Count - 2);

            long tagsim_big = b / (fib.Count - 2);
            long baghimande_big = b % (fib.Count - 2);
            for(int i=0; i<fib.Count-2; i++)
            {
                jam += fib[i];
            }

            for(int j=0; j <=baghimande; j++)
            {
                baghi += fib[j];
            }
            for(int m=0; m <= baghimande_big; m++)
            {
                baghi_big += fib[m];
            }
            return ((tagsim_big * jam + baghi_big) - (taghsim * jam + baghi))%10;
        }
    }
}
