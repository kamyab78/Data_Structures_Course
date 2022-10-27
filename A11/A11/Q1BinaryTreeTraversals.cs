
using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);
        long[][] res;
        List<long> result;
      
        public long[][] Solve(long[][] nodes)
        {
            result = new List<long>();
            res = new long[3][];
            inorder(nodes, 0);
            res[0] = result.ToArray();
            result = new List<long>();
            preorder(nodes , 0);
            res[1] = result.ToArray();
            result = new List<long>();
            postorder(nodes,0);
            res[2] = result.ToArray();
            return res;

        }

        private void postorder(long[][] nodes, long key)
        {
            if (key == -1)
                return;
            long left = nodes[key][1];
            long right = nodes[key][2];
            postorder(nodes, left);
            postorder(nodes, right);
            result.Add(nodes[key][0]);
        }

        private void preorder(long[][] nodes, long key)
        {
            if (key == -1)
                return;
            long left = nodes[key][1];
            long right = nodes[key][2];
            result.Add(nodes[key][0]);
            preorder(nodes, left);
            preorder(nodes, right);
        }

        private void inorder(long[][] nodes, long tree)
        {

            if (tree == -1)
                return;
            long left = nodes[tree][1];
            long right = nodes[tree][2];
            inorder(nodes, left);
            result.Add(nodes[tree][0]);
            inorder(nodes, right);
        }
    }
}
