using System.Runtime.Serialization;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Exceptions
{
    [DataContract]
    public class OrderBlockedFault
    {
        [DataMember]
        public string Message { get; set; }

        public OrderBlockedFault()
        {
            Message = "Order is status InProgress or Done and cant be changed";
        }
    }
}
