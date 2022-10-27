using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            long big = find_big(a, n);
            bool res = ismajorityorno(a, n, big);
            if (res == true)
                return 1;
            else
                return 0;
        }

        private bool ismajorityorno(long[] a, long n, long big)
        {
            long counter = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == big)
                    counter++;
            }

            if (counter > n / 2)
                return true;
            else
                return false;
        }

        private long find_big(long[] a, long n)
        {
            long counter = 1;
            long index = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[index] == a[i])
                    counter++;
                else
                    counter--;
                if (counter == 0)
                {
                    index = i;
                    counter = 1;
                }
            }
            return a[index];
        }
    }
}
