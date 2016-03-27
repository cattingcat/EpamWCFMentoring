using Epam.WCFMentoring.Northwind.NorthwindDbContext;
using Epam.WCFMentoring.Northwind.Services;
using Epam.WCFMentoring.Northwind.Services.CategorySvc;
using Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities;
using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using Epam.WCFMentoring.Northwind.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WCFMentoring.Northwind
{
    class Program
    {
        static void Main(string[] args)
        {
            /*NorthwindContext ctx = new NorthwindContext();
            var svc = new OrderServiceImpl(ctx);
            */
            //var res = svc.GetOrders().ToArray();

            //var res2 = svc.GetDetais(res[0].OrderID);

            /*
            var res = svc.CreateOrder(new NewOrderDTO
            {
                CustomerID = "ALFKI",
                ShipName = "some ShipName",
                ShipAddress = "some addr", 
                ShipCity = "default city",
                ShipRegion = "some region",
                ShipPostalCode  = "123123",
                ShipCountry = "Some Country"
            });
            */

            /*var res = svc.UpdateOrder(new ChangeOrderDTO
            {
                OrderID = 11080,
                CustomerID = "ALFKI",
                ShipName = "some ShipName11",
                ShipAddress = "some addr", 
                ShipCity = "default city",
                ShipRegion = "some region",
                ShipPostalCode  = "123123",
                ShipCountry = "Some Country"
            });

            svc.DeleteOrder(11080);
            */

            /*var orderSvcFactory = new ChannelFactory<IOrderService>("orderSvc");

            var instanceContext = new InstanceContext(new CallbackClass());
            var pubSubFactory = new DuplexChannelFactory<IPubSubService>(instanceContext, "pubSubEp");

            IOrderService orderSvc = orderSvcFactory.CreateChannel();
            IPubSubService pubSubSvc = pubSubFactory.CreateChannel();
            
            pubSubSvc.Subscribe();

            var list = orderSvc.GetDetais(11079);
            orderSvc.ToWork(11079);*/


            /*var categoruSvcFactory = new ChannelFactory<ICategoryService>("categorySvc");
            var categorySvc = categoruSvcFactory.CreateChannel();

            var cat = categorySvc.GetCategories().First();
            var details = categorySvc.GetDetails(new CategoryIdDTO { Id = cat.CategoryID });
            */

            var orderFactory = new ChannelFactory<IOrderService>("orderSvc");
            var _orderSvc = orderFactory.CreateChannel();

            var orders = _orderSvc.GetOrders();
            var doneOrder = orders
                .FirstOrDefault(o => o.Status == Services.OrderSvc.Entities.OrderStatus.Done);

            _orderSvc.UpdateOrder(new ChangeOrderDTO
            {
                OrderID = doneOrder.OrderID,
                ShipAddress = "Some new addr"
            });

            Console.ReadKey();
        }
    }
}
