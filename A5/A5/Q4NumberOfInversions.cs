using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            //long count = 0;
            //for(int i=0; i < n-1; i++)
            //{
            //    for(int j=i+1; j<n ;j++)
            //    if (a[i] > a[j])
            //        count++;
            //}
            //return count;

            return mergesort(a, n);
        }

        private long mergesort(long[] a, long n)
        {
            long[] temp = new long[n];
            return parttion_merge(a, temp, 0, n - 1);
        }

        private long parttion_merge(long[] a, long[] temp, long left, long right)
        {
            long mid = 0;
            long counter = 0;
            if (right > left)
            {
                mid = (right + left) / 2;
                counter = parttion_merge(a, temp, left, mid);
                counter += parttion_merge(a, temp, mid + 1, right);

                counter += calculate(a, temp, left, mid + 1, right);
            }
            return counter;

        }

        private long calculate(long[] a, long[] temp, long left, long mid, long right)
        {
            long i = left;
            long j = mid;
            long k = left;
            long counter = 0;

            while ((i <= mid - 1) && (j <= right))
            {
                if (a[i] <= a[j])
                    temp[k++] = a[i++];
                else
                {
                    temp[k++] = a[j++];
                    counter += mid - i;
                }
            }
            while (i <= mid - 1)
                temp[k++] = a[i++];
            while (j <= right)
                temp[k++] = a[j++];
            for (long n = left; n <= right; n++)
            {
                a[n] = temp[n];
            }


            return counter;

        }
    }
}
