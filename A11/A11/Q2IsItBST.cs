using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
       static long prev;
        public bool Solve(long[][] nodes)
        {
            prev = -1;   
            return Isbts(nodes,0);
        }

        private bool Isbts(long[][] nodes, long key)
        {
            if (key != -1)
            {
                if (!Isbts(nodes, nodes[key][1]))
                    return false;
                if (prev != -1 && nodes[key][0] <= nodes[prev][0])
                    return false;
                prev = key;
                return Isbts(nodes,nodes[key][2]);
            }
            return true;
        }
    }
}
