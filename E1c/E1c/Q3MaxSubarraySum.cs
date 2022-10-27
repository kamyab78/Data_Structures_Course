using System;
using System.Collections.Generic;
using TestCommon;

namespace E1c
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long result = 0;
            List<long> nums = new List<long>();
            for (int i = 0; i < n; i++)
            {
                result += numbers[i];
                nums.Add(result);
                if (result < 0)
                {
                    result = 0;
                }

            }
            long max = nums[0];
            for (int i = 0; i < nums.Count; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
            }
            return max;
        }
    }
}
