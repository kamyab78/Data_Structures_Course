using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) {
            
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);
        Dictionary<long , List<long>>adj;
        
        int[] dist;
        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
           adj= new Dictionary<long, List<long>>();
            for (int i = 0; i < nodeCount; i++)
                adj.Add(i, new List<long>());
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                adj[edges[i][0] - 1].Add(edges[i][1] - 1);
                adj[edges[i][1] - 1].Add(edges[i][0] - 1);
            }
            return short_distance( StartNode-1, EndNode-1, nodeCount);
        }

        private long short_distance( long startNode, long endNode, long nodeCount)
        {
            
            List<long> list = new List<long>();
            bool[] visit = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                visit[i] = false;
            visit[startNode] = true;
            list.Add(startNode);
            long nodes;
            long zarfiat=1;
            long counter = 0;
            while (zarfiat!=counter) {
                if (counter >= list.Count)
                    return 0;
                nodes = list[(int)counter];
                zarfiat += adj[nodes].Count;
                foreach (var node in adj[nodes])
                {
                    if (node == endNode)
                        return 1;
                    if (!visit[node])
                    {
                        visit[node] = true;
                        list.Add(node);
                    }
                }
                counter++;
            }
            return 0;   
        }


    }
}
