using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace PerfMeasurements
{
    /// <summary>
    /// Performance tests on accessing items in a collection using various techniques
    /// </summary>
    [TestClass]
    public class CollectionAccessTests
    {
        const int MAXITERATIONS = 1000000;
        const int MAX_EMPLOYEES = 1000;
        [TestMethod]
        public void ForEach()
        {
            List<Employee> employees = Util.CreateRandomArrayOfEmployees(MAX_EMPLOYEES).ToList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                foreach(var emp in employees)
                {
                    double age = emp.Age;
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("ForEach");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        [TestMethod]
        public void IndexerProperty()
        {
            List<Employee> employees = Util.CreateRandomArrayOfEmployees(MAX_EMPLOYEES).ToList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                for(int empindex=0;empindex<MAX_EMPLOYEES;empindex++)
                {
                    double age = employees[empindex].Age;
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("IndexerProperty");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        [TestMethod]
        public void Array_ArrayConversionEveryTime()
        {
            List<Employee> employees = Util.CreateRandomArrayOfEmployees(MAX_EMPLOYEES).ToList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                Employee[] arrEmployees = employees.ToArray();
                for (int empindex = 0; empindex < MAX_EMPLOYEES; empindex++)
                {
                    double age = arrEmployees[empindex].Age;
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Array_ArrayConversionEveryTime");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        [TestMethod]
        public void Array_ArrayConversionOnceOnly()
        {
            List<Employee> employees = Util.CreateRandomArrayOfEmployees(MAX_EMPLOYEES).ToList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Employee[] arrEmployees = employees.ToArray();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                for (int empindex = 0; empindex < MAX_EMPLOYEES; empindex++)
                {
                    double age = arrEmployees[empindex].Age;
                }
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Array_ArrayConversionOnceOnly");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
    }
}
