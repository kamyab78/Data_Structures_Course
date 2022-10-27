using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);
        Dictionary<long, List<long>> adj;
        public long Solve(long nodeCount, long[][] edges)
        {
            adj = new Dictionary<long, List<long> > ();
            for (int i = 0; i < nodeCount; i++)
                adj.Add(i, new List<long>());
            for(int i = 0; i < edges.Length; i++)
            {
                adj[edges[i][0] - 1].Add(edges[i][1] - 1);
                adj[edges[i][1] - 1].Add(edges[i][0] - 1);
            }
            bool[] visit = new bool[nodeCount];
        
            long javab = 0;
            for (int j = 0; j < nodeCount; j++)
            {
                if (visit[j]==false)
                {
                    call(j);
                    javab++;
                }
            }
            void call(int j)
            {
                List<long> list = new List<long>();
                visit[j] = true;
                list.Add(j);
                long nodes;
                long zarfiat = 1;
                long counter = 0;
                while (zarfiat != counter)
                {
                    if (counter >= list.Count)
                        return;
                    nodes = list[(int)counter];
                    zarfiat += adj[nodes].Count;
                    foreach (var node in adj[nodes])
                    {
                        if (!visit[node])
                        {
                            visit[node] = true;
                            list.Add(node);
                        }
                    }
                    counter++;
                }
            }




            return javab;
        }
    }
}
