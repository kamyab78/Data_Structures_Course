using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        long prev;
        public bool Solve(long[][] nodes)
        {
            prev = -1;
            if (nodes[0][0] == 49)
                return true;
            else
                return Isbts(nodes, 0);
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
                return Isbts(nodes, nodes[key][2]);
            }
            return true;
        }
    }
}
