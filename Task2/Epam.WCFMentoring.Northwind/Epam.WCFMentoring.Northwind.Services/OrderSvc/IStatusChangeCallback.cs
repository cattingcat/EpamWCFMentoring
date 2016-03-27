using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc
{
    public interface IStatusChangeCallback
    {
        [OperationContract(IsOneWay = true)]
        void StatusChange(OrderDTO order);
    }
}
