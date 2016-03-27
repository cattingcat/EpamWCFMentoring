using System;
using System.Runtime.Serialization;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities
{
    [DataContract]
    public class NewOrderDTO
    {
        [DataMember]
        public int OrderID { get; set; }

        [DataMember]
        public string CustomerID { get; set; }

        [DataMember]
        public DateTime? RequiredDate { get; set; }

        [DataMember]
        public string ShipName { get; set; }

        [DataMember]
        public string ShipAddress { get; set; }

        [DataMember]
        public string ShipCity { get; set; }

        [DataMember]
        public string ShipRegion { get; set; }

        [DataMember]
        public string ShipPostalCode { get; set; }

        [DataMember]
        public string ShipCountry { get; set; }
    }
}
