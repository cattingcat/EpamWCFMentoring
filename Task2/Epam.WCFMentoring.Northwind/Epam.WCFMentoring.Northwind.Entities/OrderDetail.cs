using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.WCFMentoring.Northwind.DbEntities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        //public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
