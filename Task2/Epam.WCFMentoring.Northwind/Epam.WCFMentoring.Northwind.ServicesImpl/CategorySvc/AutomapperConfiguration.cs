using AutoMapper;
using Epam.WCFMentoring.Northwind.DbEntities;
using Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities;

namespace Epam.WCFMentoring.Northwind.ServicesImpl.CategorySvc
{
    internal static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDTO>();
            Mapper.CreateMap<Category, CategoryDetailsDTO>()
                .ForMember(c => c.Picture, opt => opt.Ignore());
        }
    }
}
