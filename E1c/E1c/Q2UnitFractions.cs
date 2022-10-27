using System;
using System.Collections.Generic;
using TestCommon;

namespace E1c
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            long sorat = nr;
            long makhraj = dr;
            long gcd = bmm(sorat, makhraj);


            sorat /= gcd;
            makhraj /= gcd;
            if (sorat == 1)
            {
                return makhraj;
            }
            if (makhraj == 1)
            {
                return 1;
            }
            long counter = 2;
            while (sorat != 1)
            {
                if (sorat * kmm(makhraj, counter) / makhraj - 1 * kmm(makhraj, counter) / counter > 0)
                {


                    sorat = sorat * kmm(makhraj, counter) / makhraj - 1 * kmm(makhraj, counter) / counter;
                    makhraj = kmm(makhraj, counter);
                    long gcd_2 = bmm(makhraj, sorat);
                    sorat /= gcd_2;
                    makhraj /= gcd_2;

                }
                counter = makhraj / sorat + 1;
            }
            return (--counter);
        }
        public static long bmm(long a, long b)
        {
            long x = a;
            long y = b;
            while (y != 0)
            {
                long r = x % y;
                x = y;
                y = r;
            }
            return x;
        }
        public static long kmm(long a, long b)
        {
            long result = bmm(a, b);
            return (a * b) / result;
        }
    }
}
