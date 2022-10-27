using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            double capacity_1 = (double)capacity;
            int index = 0;
            double result = 0;
            double big = 0;       
            double[,] cheghali = new double[weights.Length, 2];
            for(int i=0; i < weights.Length; i++)
            {
                cheghali[i, 0] = weights[i];
                cheghali[i, 1] = (double)values[i] / (double)weights[i];
                Console.WriteLine(cheghali[i, 0] + " " + cheghali[i, 1]);
            }
            
            while (capacity_1 > 0)
            {
            for(int i = 0; i < weights.Length; i++)
                {
                    if (cheghali[i,1] > big)
                    {
                        big = cheghali[i, 1];
                        index = i;
                    }
                }
                if(capacity_1 - cheghali[index, 0] < 0)
                {
                    cheghali[index, 0] = capacity_1;
                }
                capacity_1 = capacity_1 - cheghali[index, 0];
                    result += cheghali[index, 0] * cheghali[index,1];
                cheghali[index, 1] = 0;
                big = 0;
            }
            Console.WriteLine(result);
            return (long)result;
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
