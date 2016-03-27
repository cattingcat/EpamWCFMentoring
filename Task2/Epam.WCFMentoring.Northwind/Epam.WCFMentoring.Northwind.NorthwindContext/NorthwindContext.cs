using Epam.WCFMentoring.Northwind.DbEntities;
using System.Data.Entity;

namespace Epam.WCFMentoring.Northwind.NorthwindDbContext
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(): base("name=NorthwindEntities") { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
    }
}
