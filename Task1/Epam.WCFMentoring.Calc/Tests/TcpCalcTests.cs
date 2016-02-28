using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TcpCalcTests: CalcTests
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
