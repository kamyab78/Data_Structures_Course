using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
            List<long> nums = new List<long>();
            nums.Add(stones[0]);
            long index = 0;
            if (n <= nums[0])
                return 1;
            for (int i=1; i < stones.Length; i++)
            {
                nums.Add(stones[i] + nums[i - 1]);
                if (n <= nums[i])
                {
                    index = i;
                    break;
                }
            }
            if (n > nums[nums.Count - 1])
                return 0;
            return index+1;
        }
    }
}
