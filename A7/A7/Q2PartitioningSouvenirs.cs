using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {

            if (parttion(souvenirs, souvenirsCount, 3))
                return 1;
            else
                return 0;
        }

        static bool check(long[] array, long[] sub, bool[] check_yes_or_no, long tedad_harbakhsh, int part, int andaze, int first, int last)     
        {
            if (sub[first] == tedad_harbakhsh)
            {
                if (first == part - 2)
                    return true;
                return check(array, sub, check_yes_or_no, tedad_harbakhsh,part, andaze, first + 1, andaze - 1);                                  
            }
            for (int i = last; i >= 0; i--)
            {
                if (check_yes_or_no[i])
                    continue;
                long tmp = sub[first] + array[i];
                if (tmp <= tedad_harbakhsh)
                {
                    check_yes_or_no[i] = true;
                    sub[first] += array[i];
                    bool nxt = check(array, sub, check_yes_or_no,tedad_harbakhsh, part, andaze, first, i - 1);
                    check_yes_or_no[i] = false;
                    sub[first] -= array[i];
                    if (nxt)
                        return true;
                }
            }
            return false;
        }



        static bool parttion(long[] arr, long andaze, int part)
        {
            if (andaze < part)
                return false;


            long sum = 0;
            for (int i = 0; i < andaze; i++)
                sum += arr[i];
            if (sum % part != 0)
                return false;


            long tedad_harbakhsh = sum / part;
            long[] sub = new long[part];
            bool[] check_yes_or_no = new bool[andaze];


            for (int i = 0; i < part; i++)
                sub[i] = 0;


            for (int i = 0; i < andaze; i++)
                check_yes_or_no[i] = false;



            sub[0] = arr[andaze - 1];
            check_yes_or_no[andaze - 1] = true;


            return check(arr, sub, check_yes_or_no,tedad_harbakhsh, part,(int) andaze, 0,(int) andaze - 1);
                                           
        }
    }
}
