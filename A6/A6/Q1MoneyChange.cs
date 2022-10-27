using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange : Processor
    {
        private static readonly int[] COINS = new int[] { 1, 3, 4 };

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {

            return cal(COINS, COINS.Length, n);


        }

        private long cal(int[] coins, int m, long V)
        {
 
            int[] table = new int[V + 1];
            table[0] = 0;
            for (int i = 1; i <= V; i++)
                table[i] = int.MaxValue;
            for (int i = 1; i <= V; i++)
            {
                for (int j = 0; j < m; j++)
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue &&
                            sub_res + 1 < table[i])
                            table[i] = sub_res + 1;
                    }
            }
            return table[V];
        }
    }
}
