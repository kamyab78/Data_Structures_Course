using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)

        {
            List<long> tanavob = new List<long>();
            tanavob.Add(0);
            tanavob.Add(1);
            long jam = 0;
            long index = 0;
            long result = 0;
            while (true)
            {
                tanavob.Add((tanavob[tanavob.Count - 1] + tanavob[tanavob.Count - 2])%10);
                if(tanavob[tanavob.Count-1]==1 && tanavob[tanavob.Count - 2] == 0)
                {
                    index++;
                }
                if (index == 1)
                {
                    break;
                }
            }
            Console.WriteLine(tanavob.Count - 2);
            long taghsim = n / (tanavob.Count - 2);
            long baghimande = n % (tanavob.Count - 2);
            for (int i = 0; i < tanavob.Count - 2; i++)
            {
                jam += tanavob[i];
            }
            for(int j=0; j <= baghimande; j++)
            {
                result += tanavob[j];
            }
            return (result + (jam * taghsim))%10;
        }
    }
}
