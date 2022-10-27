using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            return max(expression);
        }

        private long max(string expression)
        {
            List<long> nums = new List<long>();
            List<char> opr = new List<char>();
            string temp = "";
            for(int i = 0; i < expression.Length; i++)
            {
                if (isop(expression[i]))
                {
                    opr.Add(expression[i]);
                    nums.Add(long.Parse(temp));
                    temp = "";
                }
                else
                    temp += expression[i];
            }
            nums.Add(long.Parse(temp));
            long andaze = nums.Count;
            long[,] max_ = new long[andaze, andaze];
            long[,] min_ = new long[andaze, andaze];
            for (int i = 0; i < andaze; i++)
                for (int j = 0; j < andaze; j++)
                {
                    max_[i, j] = 0;
                    min_[i, j] = int.MaxValue;
                    if (i == j)
                    {
                       min_[i,j]= max_[i, j] = nums[i];
                    }
                }
            for(int i = 1; i < andaze; i++)
            {
                for(int j = 0; j + i < andaze; j++)
                {
                    max_[j, j + i] = calculate_max(opr,max_ , min_,j,j+i);
                    min_[j, j + i] = calculate_min(opr, max_, min_, j, j + i);
                }
            }
            return max_[0, andaze - 1];
        }

        private long calculate_min(List<char> opr, long[,] max_, long[,] min_, int first, int end)
        {
            long kochik =long.MaxValue;
            for(int i=first;i<end; i++)
            {

                kochik = Math.Min(kochik,op(max_[first,i] ,max_[i+1,end] ,opr[i]));
                kochik = Math.Min(kochik, op(max_[first, i], min_[i + 1, end], opr[i]));
                kochik = Math.Min(kochik, op(min_[first, i], max_[i + 1, end], opr[i]));
                kochik = Math.Min(kochik, op(min_[first, i], min_[i + 1, end], opr[i]));
            }
            return kochik;
        }

        private long op(long first, long second, char opr)
        {
            if (opr == '+')
            {
                return first + second;
            }
            if (opr == '-')
            {
                return first - second;
            }
            if (opr == '*')
            {
                return first * second;
            }
            return 0;
        }

        private long calculate_max(List<char> opr, long[,] max_, long[,] min_, int first, int end)
        {
                       long big =long.MinValue;
            for(int i=first;i<end; i++)
            {

                big = Math.Max(big,op(max_[first,i] ,max_[i+1,end] ,opr[i]));
                big = Math.Max(big, op(max_[first, i], min_[i + 1, end], opr[i]));
                big = Math.Max(big, op(min_[first, i], max_[i + 1, end], opr[i]));
                big = Math.Max(big, op(min_[first, i], min_[i + 1, end], opr[i]));
            }
            return big;
        }

        private bool isop(char v)
        {
            if (v == '+')
                return true;
            else if (v == '-')
                return true;
            else if (v == '*')
                return true;
            else return false;
        }
    }
}
