using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.IntegrationTests
{
    [TestClass]
    public class FaultTests
    {
        private IOrderService _orderSvc;

        [TestInitialize]
        public void ClassInit()
        {
            var orderFactory = new ChannelFactory<IOrderService>("orderSvc");
            _orderSvc = orderFactory.CreateChannel();
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OrderBlockedFault>))]
        public void UpdateOrderException()
        {
            var orders = _orderSvc.GetOrders();
            var doneOrder = orders
                .FirstOrDefault(o => o.Status == Services.OrderSvc.Entities.OrderStatus.Done);

            _orderSvc.UpdateOrder(new ChangeOrderDTO
            {
                OrderID = doneOrder.OrderID,
                ShipAddress = "Some new addr"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OrderAlreadyDoneFault>))]
        public void DeleteOrderException()
        {
            var orders = _orderSvc.GetOrders();
            var doneOrder = orders
                .FirstOrDefault(o => o.Status == Services.OrderSvc.Entities.OrderStatus.Done);

            _orderSvc.DeleteOrder(doneOrder.OrderID);
        }
    }
}
