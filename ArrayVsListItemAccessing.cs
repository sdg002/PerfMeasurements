using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    /// <summary>
    /// In this test we are comparing how long it takes to access items in an array of integers 
    /// compared with List of integers
    /// </summary>
    [TestClass]
    public class ArrayVsListItemAccessing
    {
        const int MAXITERATIONS = 1000;
        const int MAXITEMS = 1000000;
        [TestMethod]
        public void ArrayAccessing()
        {
            Stopwatch sw = new Stopwatch();
            int[] items = PopulateRandomIntegers();
            int lenofarray = items.Length;
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                for(int j=0;j<lenofarray;j++)
                {
                    int item = items[j];
                }
            }
            sw.Stop();
            Trace.WriteLine($"ArrayAccessing:Total time elapsed={sw.ElapsedMilliseconds} ms");
        }
        [TestMethod]
        public void ListAccessing()
        {
            List<int> lstItems = new List<int>();
            Stopwatch sw = new Stopwatch();
            int[] items = PopulateRandomIntegers();
            int lenofarray = items.Length;
            lstItems.AddRange(items);
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                for (int j = 0; j < lenofarray; j++)
                {
                    int item = lstItems[j];
                }
            }
            sw.Stop();
            Trace.WriteLine($"List accessing:Total time elapsed={sw.ElapsedMilliseconds} ms");
        }
        [TestMethod]
        public void ListTraversal_Enumerable()
        {
            List<int> lstItems = new List<int>();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                foreach(var o in lstItems)
                {
                    //TODO you were here
                }
            }

        }
        /// <summary>
        /// Randomly populate integers
        /// </summary>
        /// <returns></returns>
        private int[] PopulateRandomIntegers()
        {
            Random rnd = new Random(DateTime.Now.Second);
            List<int> items = new List<int>();
            for (int i = 0; i < MAXITEMS; i++)
            {
                items.Add(rnd.Next());
            }
            return items.ToArray();
        }
    }
}
