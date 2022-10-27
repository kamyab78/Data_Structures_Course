using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            return check(str);
        }

        private long check(string str)
        {
            Stack<char> stack = new Stack<char>();
            Stack<long> num = new Stack<long>();
            num.Push(1);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[' || str[i] == '{' || str[i] == '(')
                {
                    stack.Push(str[i]);
                    num.Push(i + 1);
                }
                if (str[i] == ')' || str[i] == ']' || str[i] == '}')
                {
                    if (stack.Count == 0 && num.Peek() != 1)
                        return str.Length;
                    if (stack.Count == 0 && num.Peek() == 1)
                        return i + 1;
                    if (!(match(stack.Pop(), str[i])))
                    {
                        return i + 1;
                    }
                    num.Pop();
                }
            }
            if (stack.Count == 0)
                return -1;
            else
                return num.Peek();
        }

        private bool match(char v1, char v2)
        {
            if (v1 == '(' && v2 == ')')
                return true;
            else if (v1 == '{' && v2 == '}')
                return true;
            else if (v1 == '[' && v2 == ']')
                return true;
            else
                return false;
        }
    }
}
