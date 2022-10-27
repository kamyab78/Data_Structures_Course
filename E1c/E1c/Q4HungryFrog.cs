using System;
using TestCommon;

namespace E1c
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[][] nums = new long[2][];
            nums[0] = new long[n];
            nums[1] = new long[n];
            nums[0][n - 1] = numbers[0][n - 1];
            nums[1][n - 1] = numbers[1][n - 1];
            for (long i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        nums[j][i] = Math.Max(nums[j][i + 1], nums[j + 1][i + 1] - p) + numbers[j][i];
                    }
                    else
                    {
                        nums[j][i] = Math.Max(nums[j][i + 1], nums[j - 1][i + 1] - p) + numbers[j][i];
                    }
                }
            }
            return Math.Max(nums[0][0], nums[1][0]);
        }
    }
}
