using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }
        public static int d = 256;
        public static List<long> occurrences;
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
           occurrences = new List<long>();
            int q = 101;
            serach(pattern, text, q);
            return occurrences.ToArray();
        }
        private void serach(string pattern, string text, int q)
        {
            int lenght_pattern = pattern.Length;
            int lenght_text = text.Length;
            int t = 0;
            int p = 0;
            int h = 1;
            int j;

            for (int i = 0; i < lenght_pattern - 1; i++)
                h = (h * d) % q;
            for (int i = 0; i < lenght_pattern; i++)
            {
                p = (d * p + pattern[i]) % q;
                t = (d * t + text[i]) % q;
            }
            for (int i = 0; i <= lenght_text - lenght_pattern; i++)
            {
                if (p == t)
                {
                    for (j = 0; j < lenght_pattern; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }
                    if (j == lenght_pattern)
                        occurrences.Add(i);
                }
                if (i < lenght_text - lenght_pattern)
                {
                    t = (d * (t - text[i] * h) + text[i + lenght_pattern]) % q;
                    if (t < 0)
                        t = (t + q);
                }
            }
        }

        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            long[] res = new long[T.Length - P + 1];
            string s = T.Substring(T.Length - P, P);
            res[T.Length - P] = Q2HashingWithChain.PolyHash(s, 0, P, p, x);
            long tavan = 1;
            for(int i = 0; i < P; i++)
                tavan = (tavan * x) % p;
            for(int i = T.Length - P - 1; i >= 0; i--)
            {
                res[i] = ((x * res[i + 1]) + T[i] - tavan * T[i + P]) % p;
                while (res[i] < 0)
                    res[i] += p;
            }
            return res;
        }
    }
}
