using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2a
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        long[] res;
        public long[] Solve(
            long n,
            long changeIndex,
            long changeValue,
            long[] heap)
        {
            res = heap;
            res[changeIndex] = res[changeIndex] + changeValue;
            siftdown(changeIndex);

            return res;

        }

        private void siftdown(long i)
        {
            long maxindex = i;
            long left = 3 * i + 1;
            long mid = 3 * i + 2;
            long right = 3 * i + 3;
            if (left < res.Length && res[left] < res[maxindex])
                maxindex = left;
            if (mid < res.Length && res[mid] < res[maxindex])
                maxindex = mid;
            if (right < res.Length && res[right] < res[maxindex])
                maxindex = right;
            
            if (i != maxindex)
            {
                long temp = res[i];
                res[i] = res[maxindex];
                res[maxindex] = temp;
                siftdown(maxindex);
            }
        }

 
    }
}
