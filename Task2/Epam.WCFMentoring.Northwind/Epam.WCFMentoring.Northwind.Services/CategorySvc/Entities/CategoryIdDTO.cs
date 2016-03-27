using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities
{
    [MessageContract]
    public class CategoryIdDTO
    {
        [MessageHeader]
        public int Id { get; set; }
    }
}
