using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMeasurements
{
    public class Util
    {
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
    }
}
