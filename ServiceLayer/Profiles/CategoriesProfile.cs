using AutoMapper;
using DomainLayer.Models;
using DomainLayer.Entities;

namespace ServiceLayer.Profiles
{
    class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
