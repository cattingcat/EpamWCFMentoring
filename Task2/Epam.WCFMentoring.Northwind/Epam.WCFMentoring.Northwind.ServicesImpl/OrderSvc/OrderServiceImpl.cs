using AutoMapper;
using Epam.WCFMentoring.Northwind.DbEntities;
using Epam.WCFMentoring.Northwind.NorthwindDbContext;
using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.ServicesImpl.OrderSvc
{
    public class OrderServiceImpl : NorthwindServiceBase, IOrderService
    {
        public OrderServiceImpl(): base()
        {
            AutomapperConfiguration.Configure();
        }


        public IEnumerable<OrderDTO> GetOrders()
        {
            var dbOrders = _dbContext.Orders.Take(100).AsEnumerable();
            var res = dbOrders.Select(order =>
            {
                var dtoOrder = Mapper.Map<OrderDTO>(order);
                dtoOrder.Status = GetOrderStatus(dtoOrder);

                return dtoOrder;
            });

            return res;
        }

        public DetailedOrderDTO GetDetais(int orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
                return null;

            var details = _dbContext.OrderDetails.Where(d => d.OrderID == orderId).ToArray();
            var detailsDto = Mapper.Map<IEnumerable<OrderDetailsDTO>>(details);

            var detailedOrder = Mapper.Map<DetailedOrderDTO>(order);
            detailedOrder.OrderDetails = detailsDto;
            detailedOrder.Status = GetOrderStatus(detailedOrder);

            return detailedOrder;
        }

        public OrderDTO CreateOrder(NewOrderDTO order)
        {
            var dbOrder = Mapper.Map<Order>(order);

            var addedOrder = _dbContext.Orders.Add(dbOrder);
            _dbContext.SaveChanges();

            return Mapper.Map<OrderDTO>(addedOrder);
        }

        public OrderDTO UpdateOrder(ChangeOrderDTO order)
        {
            var dbOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == order.OrderID);

            if (dbOrder == null)
                throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault());

            OrderStatus status = GetOrderStatus(dbOrder);

            if (status == OrderStatus.Done || status == OrderStatus.InProgress) 
                throw new FaultException<OrderBlockedFault>(new OrderBlockedFault());

            var dbDetails = Mapper.Map<IEnumerable<OrderDetail>>(order.OrderDetails);
            if (dbDetails != null)
            {
                foreach (var detail in dbDetails)
                {
                    detail.OrderID = dbOrder.OrderID;
                    detail.ProductID = detail.Product.ProductID;
                }
                _dbContext.OrderDetails.AddRange(dbDetails);
            }

            dbOrder.RequiredDate = order.RequiredDate;
            dbOrder.ShipAddress = order.ShipAddress;
            dbOrder.ShipCity = order.ShipCity;
            dbOrder.ShipCountry = order.ShipCountry;
            dbOrder.ShipName = order.ShipName;
            dbOrder.ShipPostalCode = order.ShipPostalCode;
            dbOrder.ShipRegion = order.ShipRegion;

            _dbContext.SaveChanges();

            var resultOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == dbOrder.OrderID);

            return Mapper.Map<OrderDTO>(resultOrder);
        }

        public void DeleteOrder(int orderId)
        {
            var dbOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);

            if (dbOrder == null)
                throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault());

            OrderStatus status = GetOrderStatus(dbOrder);

            if (status == OrderStatus.Done)
                throw new FaultException<OrderAlreadyDoneFault>(new OrderAlreadyDoneFault());

            _dbContext.Orders.Remove(dbOrder);
            _dbContext.SaveChanges();
        }

        public OrderDTO ToWork(int orderId)
        {
            var dbOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);

            if (dbOrder == null)
                throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault());

            OrderStatus status = GetOrderStatus(dbOrder);

            if (status == OrderStatus.Done)
                throw new FaultException<OrderAlreadyDoneFault>(new OrderAlreadyDoneFault());

            dbOrder.OrderDate = DateTime.UtcNow;
            _dbContext.SaveChanges();

            var res = Mapper.Map<OrderDTO>(dbOrder);
            res.Status = OrderStatus.InProgress;

            PubSubServiceImpl.NotifyAll(res);

            return res;
        }

        public OrderDTO ToDone(int orderId)
        {
            var dbOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);

            if (dbOrder == null)
                throw new FaultException<OrderNotFoundFault>(new OrderNotFoundFault());

            OrderStatus status = GetOrderStatus(dbOrder);

            if (status == OrderStatus.Done)
                throw new FaultException<OrderAlreadyDoneFault>(new OrderAlreadyDoneFault());

            dbOrder.ShippedDate = DateTime.UtcNow;
            _dbContext.SaveChanges();

            var res = Mapper.Map<OrderDTO>(dbOrder);
            res.Status = OrderStatus.Done;

            PubSubServiceImpl.NotifyAll(res);

            return res;
        }


        private static OrderStatus GetOrderStatus(OrderDTO order) 
        {
            if (order.OrderDate == null)
                return OrderStatus.New;

            if (order.ShippedDate == null)
                return OrderStatus.InProgress;

            return OrderStatus.Done;
        }

        private static OrderStatus GetOrderStatus(Order order)
        {
            if (order.OrderDate == null)
                return OrderStatus.New;

            if (order.ShippedDate == null)
                return OrderStatus.InProgress;

            return OrderStatus.Done;
        }
    }
}
