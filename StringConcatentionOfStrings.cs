using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    [TestClass]
    public class StringConcatentionOfStrings
    {
        const int MAXITERATIONS = 10000000;
        const int MAX_STRINGS = 20;
        [TestMethod]
        public void ConcatUsingStringConcatMethod()
        {
            string[] arrTest = Util.CreateRandomArrayOfString(MAX_STRINGS);
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
            string[] arrTest = Util.CreateRandomArrayOfString(MAX_STRINGS);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string r in arrTest)
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
            string[] arrTest = Util.CreateRandomArrayOfString(MAX_STRINGS);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                string sSimpleString = "";
                foreach (string r in arrTest)
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
