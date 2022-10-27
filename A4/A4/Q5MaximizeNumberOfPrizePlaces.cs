using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            long k = (long)Math.Pow(2 * n, 0.5);
           // Console.WriteLine(k);
           // long k = (long)k_1;

            if ((k*(k+1))/2 > n)
                k--;
           // Console.WriteLine(k);
            long[] nums = new long[k];
            for(int i=0; i < k; i++)
            {
                nums[i] = i+1;
                //Console.WriteLine(nums[i]);
            }
            
            nums[nums.Length - 1] = k + ((n - (k * (k + 1)) / 2));
            return nums;

        }
    }
}

