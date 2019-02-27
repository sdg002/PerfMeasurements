using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace PerfMeasurements
{
    [TestClass]
    public class FiledVsProp
    {
        const int MAXITERATIONS = 100000000;
        /// <summary>
        /// 
        /// 522 ms when using Fields
        /// 611 ms when using property values
        /// 482 ms when using Aggressive inlining
        /// The difference is marginal. Remember - 64 bit and Release mode
        /// </summary>
        [TestMethod]
        public void ClassWithProperty_Performance()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i=0;i<MAXITERATIONS;i++)
            {
                ClassWithProperty cprop = new ClassWithProperty();
                cprop.X = 100;
                cprop.Y = 200;
                int x = cprop.X;
                int y = cprop.Y;
            }
            sw.Stop();
            Trace.WriteLine($"ClassWithProperty_Performance:Total time elapsed={sw.ElapsedMilliseconds}");
        }
        /// <summary>
        /// 700 ms
        /// added code to access the property values
        /// 812 ms
        /// </summary>
        [TestMethod]
        public void ClassWithField_Performance()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                ClassWithField cfield = new ClassWithField();
                cfield.X = 100;
                cfield.Y = 200;
                int x = cfield.X;
                int y = cfield.Y;
            }
            sw.Stop();
            Trace.WriteLine($"ClassWithField_Performance:Total time elapsed={sw.ElapsedMilliseconds}");
        }
        [TestMethod]
        public void ClassWithPropertyInline_Performance()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                ClassWithPropertyInlining cpropinline = new ClassWithPropertyInlining();
                cpropinline.X = 100;
                cpropinline.Y = 200;
                int x = cpropinline.X;
                int y = cpropinline.Y;
            }
            sw.Stop();
            Trace.WriteLine($"ClassWithPropertyInlining_Performance:Total time elapsed={sw.ElapsedMilliseconds}");
        }
        [TestMethod]
        public void ClassWithBackingField_Performance()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                ClassWithBackingFieldProperty cbackingfield = new ClassWithBackingFieldProperty();
                cbackingfield.X = 100;
                cbackingfield.Y = 200;
                int x = cbackingfield.X;
                int y = cbackingfield.Y;
            }
            sw.Stop();
            Trace.WriteLine($"ClassWithBackingField_Performance:Total time elapsed={sw.ElapsedMilliseconds}");
        }
        class ClassWithProperty
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        class ClassWithBackingFieldProperty
        {
            int _x;
            int _y;

            public int X { get => _x; set => _x = value; }
            public int Y { get => _y; set => _y = value; }
        }
        class ClassWithField
        {
            public int X;
            public int Y;
        }
        class ClassWithPropertyInlining
        {
            int _x;
            int _y;
            
            public int X
            {
                [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
                get => _x;
                [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]                set => _x = value;
            }
            public int Y
            {
                [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
                get => _y;
                [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
                set => _y = value;
            }
        }

        //[MethodImpl(MethodImplOptions.NoInlining)]
    }
}
