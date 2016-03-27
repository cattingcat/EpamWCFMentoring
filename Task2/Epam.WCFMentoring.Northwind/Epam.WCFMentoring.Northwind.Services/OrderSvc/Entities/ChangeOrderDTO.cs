using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities
{
    [DataContract]
    public class ChangeOrderDTO : NewOrderDTO
    {
        [DataMember]
        public IEnumerable<OrderDetailsDTO> OrderDetails { get; set; }
    }
}
