using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Services;

namespace Tests
{
    [TestClass]
    public class HttpCalcUnitTests: CalcTests
    {
        [TestInitialize]
        public void ClassInit()
        {
            var factory = new ChannelFactory<ICalcService>("httpCalc");
            ICalcService svc = factory.CreateChannel();

            _svc = svc;
        }
    }
}
