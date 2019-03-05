using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace PerfMeasurements
{
    [TestClass]
    public class GetObjectWithMaxValue
    {
        const int MAXITERATIONS = 100000;
        const int MAX_EMPLOYEES = 1000;
        [TestMethod]
        public void EmployeeWithMaxAge_OrderByDescending()
        {
            Employee[] employees = Util.CreateRandomArrayOfEmployees(MAX_EMPLOYEES);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                Employee maxAge = employees.OrderByDescending(emp => emp.Age).FirstOrDefault();
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("OrderByDescending");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
        [TestMethod]
        public void EmployeeWithMaxAge_AggregateApproach()
        {
            Employee[] employees = Util.CreateRandomArrayOfEmployees(MAX_EMPLOYEES);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MAXITERATIONS; i++)
            {
                Employee maxAge = employees.Aggregate((e1, e2) => (e1.Age>e2.Age)?e1:e2);
            }
            sw.Stop();
            double elapsedTotal = sw.ElapsedMilliseconds;
            double elapsedAverage = elapsedTotal / MAXITERATIONS;
            Trace.WriteLine("Aggregate");
            Trace.WriteLine($"Elapsed average={elapsedAverage} ms   Elapsed Total={elapsedTotal} ms");
            Util.ThrowExceptionIfNot64BitAndNotRelease();
        }
    }
    class Employee
    {
        public double Age { get; set; }
        public override string ToString()
        {
            return $"Age={this.Age}";
        }
    }
}
