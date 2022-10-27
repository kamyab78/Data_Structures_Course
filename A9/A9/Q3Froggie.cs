using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;
using Priority_Queue;
namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        {
          
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            var p = new SimplePriorityQueue<long>();
            long counter = 0;
            List<Tuple<long, long>> ans = new List<Tuple<long, long>>();
            for (int i = 0; i < distance.Length; i++)
                ans.Add(new Tuple<long, long>(distance[i], food[i]));
            ans = ans.OrderByDescending(x => x.Item1).ToList();
            int index = 0;
            while (initialEnergy>0)
            {
                long ta = initialDistance - initialEnergy;
                if (ta <= 0)
                    break;
                for(int i = index; i < ans.Count; i++)
                {
                    if (ans[i].Item1 < ta)
                    {
                        index = i;
                        break;
                    }
                    p.Enqueue(ans[i].Item2, (float)1/ans[i].Item2);  
                  
                }
                if (p.Count == 0)
                {
                    counter = -1;
                    break;
                }
                initialDistance -= initialEnergy;    
                initialEnergy = p.Dequeue();

                counter++;
                //Console.WriteLine(initialEnergy);
            }
            return counter;
        }
    }
}
