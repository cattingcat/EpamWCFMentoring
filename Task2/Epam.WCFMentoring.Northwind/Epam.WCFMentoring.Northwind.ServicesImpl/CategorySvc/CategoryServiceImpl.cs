using AutoMapper;
using Epam.WCFMentoring.Northwind.Services.CategorySvc;
using Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.WCFMentoring.Northwind.ServicesImpl.CategorySvc
{
    public class CategoryServiceImpl: NorthwindServiceBase, ICategoryService
    {
        public CategoryServiceImpl(): base()
        {
            AutomapperConfiguration.Configure();
        }


        public IEnumerable<CategoryDTO> GetCategories()
        {
            var list = _dbContext.Categories.Take(100).AsEnumerable();

            return Mapper.Map<IEnumerable<CategoryDTO>>(list);
        }

        public CategoryDetailsDTO GetDetails(CategoryIdDTO id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryID == id.Id);

            if(category == null)
                return null;

            var byteStream = new MemoryStream(category.Picture);

            var res = Mapper.Map<CategoryDetailsDTO>(category);
            res.Picture = byteStream;

            return res;
        }

        public void UpdateCategory(CategoryDetailsDTO category)
        {
            var dbCategory = _dbContext.Categories
                .FirstOrDefault(c => c.CategoryID == category.CategoryID);

            if (dbCategory == null)
            {
                dbCategory = new DbEntities.Category();
                dbCategory.CategoryID = category.CategoryID;
                _dbContext.Categories.Attach(dbCategory);
            }

            dbCategory.CategoryName = category.CategoryName;
            dbCategory.Description = category.Description;

            using (var ms = new MemoryStream())
            {
                category.Picture.CopyTo(ms);
                dbCategory.Picture = ms.ToArray();
            }

            _dbContext.SaveChanges();
        }
    }
}
