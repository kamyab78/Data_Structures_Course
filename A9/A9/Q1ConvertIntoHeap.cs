using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
       
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
     List<Tuple<long, long>> ans = new List<Tuple<long, long>>();
        int start = (array.Length / 2) ;
            for(int i = start; i >= 0; i--)
                Heap(array, i ,ans);
           
            return ans.ToArray();
        }

        private void Heap(long[] array, int i, List<Tuple<long, long>> ans)
        {
           
            int parent = i;
            int left = 2 * i+1;
          
            if (array.Length > left && array[left] < array[parent])
                parent = left;
            int right = 2 * i + 2;
            if (array.Length > right && array[right] < array[parent])
                parent = right;
            if (parent != i)
            {
                ans.Add(new Tuple<long, long>(i, parent));
                long swap = array[i];
                array[i] = array[parent];
                array[parent] = swap;
                Heap(array, parent , ans);
            }
        }
    }
}
