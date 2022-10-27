using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            long firstmax = 0;
            long secondmax = 0;
            long indexes = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (firstmax < numbers[i])
                {
                    firstmax = numbers[i];
                    indexes = i;
                }
            }
            for(int j = 0; j < numbers.Length; j++)
            {
                if(secondmax<numbers[j] && j!=indexes)
                {
                    secondmax = numbers[j];
                }
            }
            return secondmax*firstmax;
        }
    }
}
