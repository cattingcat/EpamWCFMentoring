using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities
{
    [DataContract]
    public class DetailedOrderDTO : OrderDTO
    {
        [DataMember]
        public IEnumerable<OrderDetailsDTO> OrderDetails { get; set; }
    }
}
