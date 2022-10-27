using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long first = 0;
            long second = 1;
            long sevom = 0;
            List<long> tanavob = new List<long>();
            long index = 0;
            tanavob.Add(0);
            tanavob.Add(1);
            while (true)
            {
                tanavob.Add((tanavob[tanavob.Count-1] + tanavob[tanavob.Count - 2])%b);
                if(tanavob[tanavob.Count-1]==1 && tanavob[tanavob.Count - 2] == 0)
                {
                    index++;
                        
                }
                if(index == 1)
                {
                    break;
                }
            }

            return tanavob[(int)(a % (tanavob.Count - 2))];
        }
    }
}
