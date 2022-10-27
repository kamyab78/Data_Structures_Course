using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);
        Dictionary<long, List<long>> adj;
        public long Solve(long nodeCount, long[][] edges)
        {
            adj = new Dictionary<long, List<long>>();
            for (int i = 0; i < nodeCount; i++)
                adj.Add(i, new List<long>());
            for(int i = 0; i < edges.Length; i++)
                adj[edges[i][0] - 1].Add(edges[i][1] - 1);

            if (Dor(nodeCount))
                return 1;
            return 0;
           
        }

        private bool Dor(long nodeCount)
        {
            bool[] visit = new bool[nodeCount];
            bool[] rec = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                if (Dorutill(i, visit, rec))
                    return true;
            return false;
        }

        private bool Dorutill(long i, bool[] visit, bool[] rec)
        {
            if (rec[i])
                return true;
            if (visit[i])
                return false;
            visit[i] = true;
            rec[i] = true;
            List<long> child = adj[i];
            foreach (var c in child)
                if (Dorutill(c, visit, rec))
                    return true;
            rec[i] = false;
            return false;
        }
    }
}