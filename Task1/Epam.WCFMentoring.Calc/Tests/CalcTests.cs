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
    public class CalcTests
    {
        protected ICalcService _svc;

        [TestMethod]
        public void Test_Add()
        {
            double res = _svc.Sum(1, 2);

            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void Test_Diff()
        {
            double res = _svc.Diff(3, 2);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void Test_Mul()
        {
            double res = _svc.Mul(3, 2);

            Assert.AreEqual(6, res);
        }

        [TestMethod]
        public void Test_Div()
        {
            double res = _svc.Div(4, 2);

            Assert.AreEqual(2, res);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void Test_Div_Exception()
        {
            double res = _svc.Div(3, 0);

            Assert.AreEqual(0, res);
        }
    }
}
