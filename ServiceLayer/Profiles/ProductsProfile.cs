using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Profiles
{
    class ProductsProfile :Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductForCreationDTO, Product>().ReverseMap();
            CreateMap<ProductForUpdateDTO, Product>().ReverseMap();
            
        }
    }
}
