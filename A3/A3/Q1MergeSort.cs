using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {

            Merge_Sort(a, 0, a.Length - 1);
            return a;

        }

  


        private void Merge(long[] input, long left, long middle, long right)
        {
            long s_1 = middle - left + 1;
            long s_2 = right - middle;
            long[] leftArray = new long[s_1];
            long[] rightArray = new long[s_2];

            Array.Copy(input, left, leftArray, 0, s_1);
            Array.Copy(input, middle + 1, rightArray, 0, s_2);

            int i = 0;
            int j = 0;
            for (long k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }
        private void Merge_Sort(long[] a, long left, long right)
        {
            if (left < right)
            {
                long middle = (left + right) / 2;

                Merge_Sort(a, left, middle);
                Merge_Sort(a, middle + 1, right);

                Merge(a, left, middle, right);
            }
        }
    }
}
