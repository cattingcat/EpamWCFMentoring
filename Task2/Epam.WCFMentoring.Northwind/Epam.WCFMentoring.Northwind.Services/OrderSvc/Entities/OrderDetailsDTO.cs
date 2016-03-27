using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities
{
    [DataContract]
    public class OrderDetailsDTO
    {
        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public short Quantity { get; set; }

        [DataMember]
        public float Discount { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }
    }
}
