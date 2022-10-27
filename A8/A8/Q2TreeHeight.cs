using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {

            long root = 0;
            long[] omgh = new long[nodeCount];
            List<long>[] mojaverat = new List<long>[nodeCount];
            Queue check = new Queue();

            for (int i = 0; i < nodeCount; i++)
            {
                mojaverat[i] = new List<long>();
            }

            for (int i = 0; i < nodeCount; i++)
            {
                omgh[i] = 0;
                if (tree[i] == -1)
                {
                    root = i;
                }
                else
                {
                    mojaverat[i].Add(tree[i]);
                    mojaverat[tree[i]].Add(i);
                }
            }
            omgh[root] = 1;
            check.Enqueue(root);
            while (check.Count > 0)
            {
                long ras = (long)check.Dequeue();
                for (int i = 0; i < mojaverat[ras].Count; i++)
                {
                    if (omgh[mojaverat[ras][i]] == 0)
                    {
                        omgh[mojaverat[ras][i]] = 1 + omgh[ras];
                        check.Enqueue(mojaverat[ras][i]);
                    }
                }
            }
            return omgh.Max();
        }

   

        //private void DFS(List<long>[] mojaverat, long[] omgh, long root)
        //{
        //    bool[] visit = new bool[omgh.Length];
        //    visit[root] = true;
        //    if (mojaverat[root].Count == 0)
        //        return;
        //    for(int i=0; i<mojaverat[root].Count ; i++)
        //        {
        //        //if(visit[mojaverat[root][i]])


        //        }
        //}
    }

}
