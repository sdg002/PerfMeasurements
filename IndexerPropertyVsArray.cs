using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfMeasurements
{
    [TestClass]
    public class IndexerPropertyVsArray
    {
        [TestMethod]
        public void TestMethod1()
        {
            //simulate //Matrix2d accessing through indexer vs raw array access
            //LOW PRIORITY, WE REALLY CANNOT CHANGE THE BEHAVIOUR OF INDEXER PROPERTY
        }
    }
}
