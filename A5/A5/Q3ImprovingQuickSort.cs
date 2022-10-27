using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {

            quicksort(a, 0, n - 1);


            return a;
        }
        private void quicksort(long[] a, long low, long high)
        {
            if (low >= high)
                return;

            long i = 0, j = 0;
            partion(a, low, high, ref i, ref j);
            quicksort(a, low, i);
            quicksort(a, j, high);

        }
        private void partion(long[] a, long low, long high, ref long i, ref long j)
        {
            if (high - low <= 1)
            {
                if (a[high] < a[low])
                    swap(ref a[high], ref a[low]);
                i = low;
                j = high;
                return;
            }

            long mid = low;
            long pivot = a[high];
            while (mid <= high)
            {
                if (a[mid] < pivot)
                    swap(ref a[low++], ref a[mid++]);
                else if (a[mid] == pivot)
                    mid++;
                else if (a[mid] > pivot)
                    swap(ref a[mid], ref a[high--]);
            }

            i = low - 1;
            j = mid;
        }

        static void swap(ref long first, ref long second)
        {
            long temp = 0;
            temp = first;
            first = second;
            second = temp;
        }
    }
}
