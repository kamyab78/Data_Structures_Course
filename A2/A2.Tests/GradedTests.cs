using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Random ran = new Random();
            Stopwatch sw = new Stopwatch();
sw.Start();
            while (sw.ElapsedMilliseconds>5000)
            {
               
                long []random_number = new long[5];
                for (int i = 0; i < random_number.Length; i++)
                {
                    long r=ran.Next(1, 5);
                    random_number[i] = r;

                    Console.WriteLine(r + " ");

                }
                A2.Q1NaiveMaxPairWise q1 = new Q1NaiveMaxPairWise("");
                A2.Q2FastMaxPairWise q2 = new Q2FastMaxPairWise("");
                long q1_number = q1.Solve(random_number);
                long q2_number = q2.Solve(random_number);
                if (q1_number!=q2_number )
                {
                    Console.WriteLine(q1_number + " " + q2_number);
                    Assert.IsFalse(true);
                       
                }
       
                

            }
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}