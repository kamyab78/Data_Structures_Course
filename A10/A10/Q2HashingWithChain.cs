using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {

        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);
        long bucket;
        Dictionary<int, LinkedList<string>> dict;
        public string[] Solve(long bucketCount, string[] commands)
        {
            bucket = bucketCount;
            dict = new Dictionary<int, LinkedList<string>>();
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            long tavan = 1;
            for(int i = start; i < start + count; i++)
            {
                hash = (hash + str[i] * tavan) % p;
                tavan = (tavan*x) % p;
            }
            return hash;
        }

        public void Add(string str)
        {
            int index = (int)(PolyHash(str, 0, str.Length) % bucket);
            if (!dict.ContainsKey(index))
                dict[index] = new LinkedList<string>();
            else
            {
                if (dict[index].Contains(str))
                    return;
            }
            dict[index].AddFirst(str);
           
        }

        public string Find(string str)
        {
            int index = (int)(PolyHash(str, 0, str.Length) % bucket);
            if (!dict.ContainsKey(index))
                return "no";
            if (dict[index].Contains(str))
                return "yes";
            return "no";
        }

        public void Delete(string str)
        {
            int index = (int)(PolyHash(str, 0, str.Length) % bucket);
            if (!dict.ContainsKey(index))
                return;
            dict[index].Remove(str);
        }

        public string Check(int i)
        {
            string out_ = "";
            string str ;
            if (!dict.ContainsKey(i))
                return "-";
            for (int j = 0; j < dict[i].Count; j++)
            {
                str = dict[i].ElementAt(j);
                if (j == dict[i].Count - 1)
                    out_ += str;
                else
                    out_ += str + " ";
                
            }
            if (out_ == "")
                return "-";
            return out_;
        }

    }
}
