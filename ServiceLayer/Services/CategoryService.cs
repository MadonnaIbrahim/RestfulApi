using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services
{
   public class CategoryService : ICategoryService
    {
        public readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
                
        }
        public IEnumerable<CategoryDTO> getCategories()
        {
            IEnumerable<CategoryDTO> allCategories=null; 
            try
            {
                IEnumerable<Category> categories= _categoryRepo.GetAll();
                allCategories= _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allCategories;
        }
    }
}
