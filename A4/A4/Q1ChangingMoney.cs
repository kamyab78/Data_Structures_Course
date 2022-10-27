using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            long ten_coin = 0;
            long one_coin = 0;
            long five_coin = 0;


            ten_coin = money / 10;
            money = money - (ten_coin * 10);
            five_coin = money / 5;
            money = money - (five_coin * 5);
            one_coin = money;

            return one_coin + five_coin + ten_coin;
            }
        }
    }

