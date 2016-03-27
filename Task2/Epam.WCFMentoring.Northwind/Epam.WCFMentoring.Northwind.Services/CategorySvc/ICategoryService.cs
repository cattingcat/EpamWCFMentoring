using Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.CategorySvc
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        IEnumerable<CategoryDTO> GetCategories();

        [OperationContract]
        CategoryDetailsDTO GetDetails(CategoryIdDTO id);

        [OperationContract]
        void UpdateCategory(CategoryDetailsDTO category);
    }
}
