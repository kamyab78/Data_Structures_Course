using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q4OrderOfCourse: Processor
    {
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);
        Dictionary<long, List<long>> adj;
        public long[] Solve(long nodeCount, long[][] edges)
        {
            List<long> res = new List<long>();
            Stack<long> stack = new Stack<long>();
            bool[] visit = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                visit[i] = false;
            adj = new Dictionary<long, List<long>>();
            for (int i = 0; i < nodeCount; i++)
                adj.Add(i, new List<long>());
            for (int i = 0; i < edges.Length; i++)
                adj[edges[i][0] - 1].Add(edges[i][1] - 1);
            topol();
            void topol()
            {
                for (int i = 0; i < nodeCount; i++)
                    if (visit[i] == false)
                        topolutill(i);

                while (stack.Count != 0)
                    res.Add(stack.Pop()+1);
            }

             void topolutill(long v)
            {
                visit[v] = true;

                foreach (var nodes in adj[v])
                    if (!visit[nodes])
                        topolutill(nodes);
                stack.Push(v);
            }

            return res.ToArray();

        }

     

        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");

        }
    }
}
