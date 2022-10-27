using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);
        List<long> result;
        public long[] Solve(long n, long[] BST)
        {
            result = new List<long>();
            order(BST, 0);
            return result.ToArray();
        }

        private void order(long[] bST, int key)
        {
            if (bST[key] == -1)
                return;
            int left = 2 * key + 1;
            int right = 2 * key + 2;
            order(bST, left);
            result.Add(bST[key]);
            order(bST, right);

        }
    }
}