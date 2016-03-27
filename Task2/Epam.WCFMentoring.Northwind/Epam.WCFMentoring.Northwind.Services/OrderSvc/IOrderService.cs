using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Exceptions;
using System.Collections.Generic;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IEnumerable<OrderDTO> GetOrders();

        [OperationContract]
        DetailedOrderDTO GetDetais(int orderId);

        [OperationContract]
        OrderDTO CreateOrder(NewOrderDTO order);

        [OperationContract]
        [FaultContract(typeof(OrderBlockedFault))]
        [FaultContract(typeof(OrderNotFoundFault))]
        OrderDTO UpdateOrder(ChangeOrderDTO order);

        [OperationContract]
        [FaultContract(typeof(OrderNotFoundFault))]
        [FaultContract(typeof(OrderAlreadyDoneFault))]
        void DeleteOrder(int orderId);

        [OperationContract]
        [FaultContract(typeof(OrderNotFoundFault))]
        [FaultContract(typeof(OrderAlreadyDoneFault))]
        OrderDTO ToWork(int orderId);

        [OperationContract]
        [FaultContract(typeof(OrderNotFoundFault))]
        [FaultContract(typeof(OrderAlreadyDoneFault))]
        OrderDTO ToDone(int orderId);
    }
}
