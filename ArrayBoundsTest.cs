using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    [TestClass]
    public class ArrayBoundsTest
    {
        const int MAXITERATIONS = 100000000;

        /// <summary>
        /// 541 ms
        /// </summary>
        [TestMethod]
        public void GetUpperBoundMethod_FiredEveryTime()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ClassToWrapUpArrayBounds wrap = new ClassToWrapUpArrayBounds(new int[101]);
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                //ClassWithProperty cprop = new ClassWithProperty();
                //cprop.X = 100;
                //cprop.Y = 200;
                //int x = cprop.X;
                //int y = cprop.Y;
                int upper = wrap.UpperBound1;
            }
            sw.Stop();
            Trace.WriteLine($"ClassToWrapUpArrayBounds_GetUpperBoundFired_Performance:Total time elapsed={sw.ElapsedMilliseconds}");

        }
        /// <summary>
        /// 37 ms
        /// </summary>
        [TestMethod]
        public void GetUpperBoundMethod_Cached()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ClassToWrapUpArrayBounds wrap = new ClassToWrapUpArrayBounds(new int[101]);
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                //ClassWithProperty cprop = new ClassWithProperty();
                //cprop.X = 100;
                //cprop.Y = 200;
                //int x = cprop.X;
                //int y = cprop.Y;
                int upper = wrap.UpperBound2;
            }
            sw.Stop();
            Trace.WriteLine($"ClassToWrapUpArrayBounds_Cached_Performance:Total time elapsed={sw.ElapsedMilliseconds}");

        }
    }
    class ClassToWrapUpArrayBounds
    {
        int[] _arr;
        int _upperbound;
        public ClassToWrapUpArrayBounds(int[] x)
        {
            _arr = x;
            _upperbound = _arr.GetUpperBound(0);
        }
        public int UpperBound1 { get => _arr.GetUpperBound(0);  }
        public int UpperBound2 { get => _upperbound; }
    }
}
