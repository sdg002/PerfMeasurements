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
    public class StringConcatentionOfNumbers
    {
        const int MAXITERATIONS = 10000000;
        const int MAXCOUNTOF_INTEGERS = 20;
        [TestMethod]
        public void ConcatUsingStringConcatMethod()
        {
            int[] arrTest = Util.CreateRandomArrayOfInt(MAXCOUNTOF_INTEGERS);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                string output = string.Concat(arrTest);
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("String.Concat method");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        [TestMethod]
        public void ConcatUsingStringBuilder()
        {
            int[] arrTest = Util.CreateRandomArrayOfInt(MAXCOUNTOF_INTEGERS);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                StringBuilder sb = new StringBuilder();
                foreach(int r in arrTest)
                {
                    sb.Append(r);
                }
                string output = sb.ToString();
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("StringBuilder");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        [TestMethod]
        public void ConcatUsingStringSimpleAddition()
        {
            int[] arrTest = Util.CreateRandomArrayOfInt(MAXCOUNTOF_INTEGERS);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                string sSimpleString = "";
                foreach(int r in arrTest)
                {
                    sSimpleString += r.ToString();

                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Simple addition of strings");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
    }
}
