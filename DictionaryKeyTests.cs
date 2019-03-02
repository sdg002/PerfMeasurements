using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace PerfMeasurements
{
    /*
     * 
     * 
     * Performance comparison to access Dictionary between "long" and "string" keys
     * 
     *  String key
     *  ----------
     *      0.026 ms per iteration
     *  Long key
     *  ---------
     *      0.010 ms per iteration
     * 
     */
    [TestClass]
    public class DictionaryKeyTests
    {
        Random _rnd = new Random(DateTime.Now.Second);
        const int MAXITEMS = 1000;
        public Random Rnd
        {
            get
            {
                return _rnd;
            }
        }
        /// <summary>
        /// Test a Dictionary<> where the key is of type "String"
        /// </summary>
        [TestMethod]
        public void StringKey()
        {
            string[] keys = new string[MAXITEMS];
            Dictionary<string, double> dict = new Dictionary<string, double>();
            ///
            /// Create some key value pairs
            ///
            for(int i=0;i<MAXITEMS;i++)
            {
                keys[i] = i.ToString();
                dict.Add(keys[i], _rnd.NextDouble());
            }
            string[] keysRandom = keys.OrderBy(k => this.Rnd.Next()).ToArray();
            const int MAXITERATIONS = 100000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                for (int itemindex = 0; itemindex < MAXITEMS; itemindex++)
                {
                    String keyRandom = keysRandom[itemindex];
                    double value = dict[keyRandom];
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        /// <summary>
        /// Test a Dictionary<> Dictionary where the key is of type "long"
        /// </summary>
        [TestMethod]
        public void LongKey()
        {
            const int MAXITEMS = 1000;
            long[] keys = new long[MAXITEMS];
            Dictionary<long, double> dict = new Dictionary<long, double>();
            ///
            /// Create some key value pairs
            ///
            for (long i = 0; i < MAXITEMS; i++)
            {
                keys[i] = i;
                dict.Add(keys[i], _rnd.NextDouble());
            }
            long[] keysRandom = keys.OrderBy(k => this.Rnd.Next()).ToArray();
            const int MAXITERATIONS = 100000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                for (int itemindex = 0; itemindex < MAXITEMS; itemindex++)
                {
                    long keyRandom = keysRandom[itemindex];
                    double value = dict[keyRandom];
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Dictionary with long key");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
    }
}
