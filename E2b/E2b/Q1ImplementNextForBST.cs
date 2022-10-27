using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
          //  this.ExcludeTestCaseRangeInclusive(1, 4);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }
        long[] res;
        long v;
        public long Solve(long n, long node, long[] BST)
        {
            res = BST;
            v = node;
            long left = 2 * node + 1;
            long right = 2 * node + 2;
           
            if (res[right] != -1)
                return LeftDescendant(right);
            else
                return RightAncestor(node);
        }

        private long RightAncestor(long node)
        {
            long parent;
            if (node%2==0)
            parent = (node - 2) / 2;
            else
                parent = (node - 1) / 2;
            if (parent >= 0)
            {
                if (res[node] < res[parent])
                    return parent;
                else
                    return RightAncestor(parent);
            }
            else return -1;
        }

        private long LeftDescendant(long right)
        {
            long left = 2 * right + 1;
            if (res[left] == -1)
                return right;
            else
               return LeftDescendant(left);
        }
    }
}

