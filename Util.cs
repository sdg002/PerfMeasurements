using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMeasurements
{
    public class Util
    {
        private static Random _rnd = new Random(DateTime.Now.Second);
        /// <summary>
        /// Throws an Exception if any of the following conditions are met:
        ///     1)Code is compiled in Debug mode 
        ///     2)32 bit
        /// </summary>
        /// <param name="ignore">When set to True, all checks are silently ignored</param>
        public static void ThrowExceptionIfNot64BitAndNotRelease(bool ignore=false)
        {
            if (ignore == true) return;
#if DEBUG
            throw new Exception("This test will only work in Release mode");            
#endif
            if (Environment.Is64BitProcess==false)
            {
                throw new Exception("This test will work in 64 bit only");
            }
        }
        /// <summary>
        /// Creates an array of Int with the specified number of random numbers
        /// </summary>
        /// <param name="count">Total no. of random nos to generate</param>
        /// <returns></returns>
        internal static int[] CreateRandomArrayOfInt(int count)
        {
            List<int> results = new List<int>();
            for(int index=0;index<count;index++)
            {
                int r = _rnd.Next();
                results.Add(r);
            }
            return results.ToArray();
        }
        /// <summary>
        /// Creates an array of strings with the specified count of random strings
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        internal static string[] CreateRandomArrayOfString(int count)
        {
            int[] numbers = CreateRandomArrayOfInt(count);
            string[] strings = numbers.Select(n => n.ToString()).ToArray();
            return strings.ToArray();
        }
        internal static Employee[] CreateRandomArrayOfEmployees(int count)
        {
            List<Employee> lst = new List<Employee>();
            for (int index = 0; index < count; index++)
            {
                var emp = new Employee();
                emp.Age= _rnd.NextDouble() * 50 + 18;
                lst.Add(emp);
            };
            return lst.ToArray();
        }
    }
}
