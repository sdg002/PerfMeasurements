using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Inspired by AndrewNgs video on the importance of not using for loops in Python, rather use vectorization
        /// https://www.youtube.com/watch?v=9YHWgxwzwD8&index=15&list=PLBAGcD3siRDguyYYzhVwZ3tLvOyyG5k6K
        /// 
        /// It took 1.5-2 ms for a dot product for 1 million items
        /// </summary>
        [TestMethod]
        public void DotProductMillionItems()
        {
            const int ARRAYSIZE = 1000000;
            double[] a1 = new double[ARRAYSIZE];
            double[] a2 = new double[ARRAYSIZE];
            Random rnd = new Random(DateTime.Now.Second);
            for (int i = 0; i < ARRAYSIZE; i++) a1[i] = rnd.NextDouble();
            for (int i = 0; i < ARRAYSIZE; i++) a2[i] = rnd.NextDouble();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            double dotproduct = 0.0;
            for(int i=0;i<ARRAYSIZE;i++)
            {
                dotproduct += a1[i] * a2[i];
            }
            sw.Stop();
            TimeSpan sp = sw.Elapsed;
            double elapsedTotal = sp.TotalMilliseconds; //sw.ElapsedMilliseconds;
            Trace.WriteLine("Dotproduct");
            Trace.WriteLine($"Elapsed Total={elapsedTotal} ms");

        }
    }
}
