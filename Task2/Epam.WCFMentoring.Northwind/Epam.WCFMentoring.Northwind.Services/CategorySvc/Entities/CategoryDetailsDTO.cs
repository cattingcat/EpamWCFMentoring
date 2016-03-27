using System.IO;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities
{
    [MessageContract]
    public class CategoryDetailsDTO: CategoryDTO
    {
        [MessageBodyMember]
        public Stream Picture { get; set; }
    }
}
