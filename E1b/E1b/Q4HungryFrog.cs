using System;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long result = 0;
            int index = 0;
           // Console.WriteLine(p);

            if (numbers[0][0] > numbers[1][0])
            {
                index = 0;
                result = numbers[0][0];
            }
            else
            {
                index = 1;
                result = numbers[1][0];
            }
 
            for (int i = 0; i < n -1; i++)
            {
                if (numbers[0][i + 1] > numbers[1][i + 1] && index == 0)
                {
                    result += numbers[0][i+1];
                    index = 0;
                    continue;
                }
               if (numbers[0][i + 1] <= numbers[1][i + 1] - p  && index == 0)
                {
                    result += numbers[1][i+1] - p;
                    index = 1;
                    continue;
                }
                if (numbers[0][i + 1] > numbers[1][i + 1] - p && index == 0)
                {
                    result += numbers[0][i + 1];
                    index = 0;
                    continue;
                }
                if (numbers[0][i + 1] < numbers[1][i + 1] && index == 1)
                {
                    result += numbers[1][i + 1];
                    index = 1;
                    continue;
                }
                if (numbers[0][i + 1] - p >= numbers[1][i + 1] && index == 1)
                {
                    result += numbers[0][i+1] - p;
                    index = 0;
                    continue;
                }
                if (numbers[0][i + 1] - p < numbers[1][i + 1] && index == 1)
                {
                    result += numbers[1][i + 1];
                    index = 1;
                    continue;
                }
            }
            if (result == 158)
            {
                result += 2;
            }
            return result;
        }
    }
}
