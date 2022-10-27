using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>)Solve);


        public virtual string Solve(long n, long[] numbers)
        {
            string res = "";
            for (int j = 0; j < numbers.Length; j++)
            {
                long max = 0;
                int index = 0;
                for (int i = 0; i < numbers.Length; i++)
                {

                    if (safe_max(max, numbers[i]))
                    {
                        max = numbers[i];
                        index = i;
                    }

                }
                numbers[index] = 0;
                res += max;
            }
            return res;
        }
        private bool safe_max(long max, long v)
        {
            string A = max +""+ v;
            string B = v + "" + max;
            if (long.Parse(A) < long.Parse(B))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}

      