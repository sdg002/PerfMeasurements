using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    /// <summary>
    /// Linq Sum takes 4 times the time taken
    /// </summary>
    [TestClass]
    public class LinqTests
    {
        const int MAXITEMS = 1000;
        Random _rnd = new Random(DateTime.Now.Second);
        public Random Rnd
        {
            get
            {
                return _rnd;
            }
        }
        [TestMethod]
        public void LinqSelectAndSummation()
        {
            double[] randomvalues = GenerateArrayOfRandomValues(MAXITEMS);
            const int MAXITERATIONS = 100000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                //double sum = randomvalues.Select(val => val).Sum();
                double sum = randomvalues.Sum();
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Linq Select and Sum");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal}");

        }
        [TestMethod]
        public void RawSummation()
        {
            double[] randomvalues = GenerateArrayOfRandomValues(MAXITEMS);
            const int MAXITERATIONS = 100000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                double summation = 0;
                foreach(long value in randomvalues)
                {
                    summation += value;
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine($"Raw summation");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal}");

        }

        private double[] GenerateArrayOfRandomValues(int mAXITEMS)
        {
            double[] randomvalues = new double[MAXITEMS];
            for (long i = 0; i < MAXITEMS; i++)
            {
                randomvalues[i] = Rnd.NextDouble();
            }
            return randomvalues;
        }
    }
}
