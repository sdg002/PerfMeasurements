using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    /// <summary>
    /// 
    /// 
    /// The performance of String.Concat and StringBuilder is identical!!
    /// 
    /// 
    /// 
    /// </summary>
    [TestClass]
    public class StringConcat
    {
        const int MAXITERATIONS = 10000000;
        [TestMethod]
        public void ConcatUsingStringConcatMethod()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                long l1 = 100;
                long l2 = 200;
                long l3 = 300;
                long l4 = 400;
                long l5 = 500;
                string output = string.Concat(l1, l2, l3, l4,l5);
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("String.Concat method");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");

        }
        [TestMethod]
        public void ConcatUsingStringBuilder()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                long l1 = 100;
                long l2 = 200;
                long l3 = 300;
                long l4 = 400;
                long l5 = 500;
                StringBuilder sb = new StringBuilder();
                sb.Append(l1);
                sb.Append(l2);
                sb.Append(l3);
                sb.Append(l4);
                sb.Append(l5);
                string output = sb.ToString();
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("StringBuilder");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
        }
        [TestMethod]
        public void ConcatUsingStringSimpleAddition()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                long l1 = 100;
                long l2 = 200;
                long l3 = 300;
                long l4 = 400;
                long l5 = 500;
                string sSimpleString = "";
                sSimpleString+=(l1);
                sSimpleString+=(l2);
                sSimpleString += (l3);
                sSimpleString += (l4);
                sSimpleString += (l5);
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Simple addition");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");

        }
        [TestMethod]
        public void DoLongMultiply()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                long l1 = 100;
                long l2 = 200;
                long l3 = 300;
                long l4 = 400;
                long l5 = 500;
                long output = l1 + l2 * 1000 + l3 * 1000 * 1000 + l4 * 1000 * 1000 * 1000 + l5 * 1000 * 1000 * 1000 * 1000;
                string soutput = output.ToString();
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("DoLongMultiply");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
        }
    }
}
