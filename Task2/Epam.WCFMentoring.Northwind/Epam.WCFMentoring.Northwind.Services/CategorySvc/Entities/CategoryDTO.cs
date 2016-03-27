using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities
{
    [MessageContract]
    public class CategoryDTO
    {
        [MessageHeader]
        public int CategoryID { get; set; }

        [MessageHeader]
        public string CategoryName { get; set; }

        [MessageHeader]
        public string Description { get; set; }
    }
}
