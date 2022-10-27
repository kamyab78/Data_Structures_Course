using System;
using System.Collections.Generic;
using TestCommon;

namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            List<long> nums = new List<long>();
            long x = n;
            int index = 0;
            long result = 0;
            while (x > 0)
            {

                for (int i = index; i < n; i++)
                {
                    if (numbers[i] < 0)
                    {
                        numbers[i] = 0;
                        break;
                    }

                    result += numbers[i];
                }

                nums.Add(result);
                result = 0;
                index++;
                x--;
            }


            long big = 0;
            for (int m = 0; m < nums.Count; m++)
            {
                if (big < nums[m])
                {
                    big = nums[m];
                }
            }

            return big;
            }
        }
    }

