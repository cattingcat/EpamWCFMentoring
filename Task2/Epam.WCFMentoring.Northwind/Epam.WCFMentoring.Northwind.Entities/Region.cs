using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.WCFMentoring.Northwind.DbEntities
{
    [Table("Region")]
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }

        //public virtual ICollection<Territory> Territories { get; set; }
    }
}
