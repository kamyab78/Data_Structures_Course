using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] TableSizes;
        long[] rank;
        long ans;
        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            List<long> res = new List<long>();
            parent = new long[tableSizes.Length];
            TableSizes = tableSizes;
            for (int i = 0; i < parent.Length; i++)
                parent[i] = i;
            ans= tableSizes.Max();
            for (int i = 0; i < targetTables.Length; i++)
            {
                merg(targetTables[i] - 1, sourceTables[i] - 1);
                res.Add(ans);
            }
            return res.ToArray();
        }

        private void merg(long target, long source)
        {
            long realsource = getparent(source);
            long realtarget = getparent(target);
           
            if (realsource == realtarget)
                return ;

            parent[realsource] = parent[realtarget];
            TableSizes[realtarget] += TableSizes[realsource];
            TableSizes[source] = 0;
            ans = Math.Max(ans, TableSizes[realtarget]);
        }

        private long getparent(long source)
        {
            if (source == parent[source])
                return source;
            return getparent(parent[source]);
        }

    }
}
