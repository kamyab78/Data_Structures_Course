using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            if (nr == 1)
            {
                return dr;
            }
            if (nr > dr )
            {
                if(bmm(nr, dr) == dr)
                return 1;
                if (nr - dr == 1)
                    return dr;
            }
            long gcd = bmm(nr, dr);
            if (gcd != 0)
            {
                nr = nr / gcd;
                dr = dr / gcd;
            }

            return (nr * dr);
        }

        private long bmm(long nr, long dr)
        {
            long smal = nr;
            long big = dr;
            while (smal != 0)
            {
                long r = big % smal;
                big = smal;
                smal = r;
            }
            return big;
        }
    }
}
