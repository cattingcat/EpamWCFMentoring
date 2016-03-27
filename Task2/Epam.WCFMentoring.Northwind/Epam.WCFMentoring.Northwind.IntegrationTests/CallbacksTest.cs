using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using System.Threading;

namespace Epam.WCFMentoring.Northwind.IntegrationTests
{
    [TestClass]
    public class CallbacksTest
    {
        private IOrderService _orderSvc;
        private IPubSubService _pubSubSvc;
        private TestCallbackClass _callbackObj;

        [TestInitialize]
        public void ClassInit()
        {
            var orderFactory = new ChannelFactory<IOrderService>("orderSvc");

            _callbackObj = new TestCallbackClass();

            var instanceContext = new InstanceContext(_callbackObj);
            var pubSubFactory = new DuplexChannelFactory<IPubSubService>(instanceContext, "pubSubEp");

            _orderSvc = orderFactory.CreateChannel();
            _pubSubSvc = pubSubFactory.CreateChannel();
        }

        [TestMethod]
        public void TestCallbackFired()
        {
            _pubSubSvc.Subscribe();
            var order = _orderSvc.ToWork(11079);
            Thread.Sleep(1000);
            Assert.AreEqual(order.OrderID, _callbackObj.ChangedOrder.OrderID);
        }

        [TestMethod]
        public void MultiSubscribe()
        {
            _pubSubSvc.Subscribe();
            _pubSubSvc.Subscribe();
            _pubSubSvc.Subscribe();

            var order = _orderSvc.ToWork(11079);
            Thread.Sleep(1000);
            Assert.AreEqual(order.OrderID, _callbackObj.ChangedOrder.OrderID);
        }

        [TestMethod]
        public void MultiUnsubscribe()
        {
            _pubSubSvc.Unsubscribe();
            _pubSubSvc.Unsubscribe();
            _pubSubSvc.Unsubscribe();
        }

        [TestMethod]
        public void NotifyDisconnected()
        {
            _pubSubSvc.Subscribe();
            var clientChannel = (IClientChannel)_pubSubSvc;
            clientChannel.Abort();

            var order = _orderSvc.ToWork(11079);
            Thread.Sleep(1000);
            Assert.IsNull(_callbackObj.ChangedOrder);
        }
    }
}
