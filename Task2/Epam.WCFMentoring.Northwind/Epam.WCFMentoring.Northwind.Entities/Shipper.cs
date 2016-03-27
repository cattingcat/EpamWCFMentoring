using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epam.WCFMentoring.Northwind.DbEntities
{
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
