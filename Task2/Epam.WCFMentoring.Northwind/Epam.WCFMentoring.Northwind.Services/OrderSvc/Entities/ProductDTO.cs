using System.Runtime.Serialization;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities
{
    [DataContract]
    public class ProductDTO
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string QuantityPerUnit { get; set; }

        [DataMember]
        public decimal? UnitPrice { get; set; }

        [DataMember]
        public short? UnitsInStock { get; set; }

        [DataMember]
        public short? UnitsOnOrder { get; set; }

        [DataMember]
        public short? ReorderLevel { get; set; }

        [DataMember]
        public bool IsDiscontinued { get; set; }
    }
}
