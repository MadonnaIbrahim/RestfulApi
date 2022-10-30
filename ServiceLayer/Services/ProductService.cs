using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        public readonly IRepository<Product> _productRepo;
        public readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> productRepo, IRepository<Category> categoryRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;

        }
        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> allProducts = null;
            try
            {
                var products = _productRepo.GetAll().ToList();
                allProducts = _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allProducts;
        }

        public ProductDTO GetProduct(Guid productId)
        {
            ProductDTO productDto = null;
            try
            {
                if (!_productRepo.ItemExists(productId))
                {
                    return null;
                }
                Product product = _productRepo.Get(productId);
                productDto = _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productDto;
        }

        public List<ProductDTO> GetProducts(Guid categoryId)
        {
            List<ProductDTO> allProducts = null;
            try
            {
                IEnumerable products = null;

                if (categoryId == null || categoryId==Guid.Empty)
                {
                    products = _productRepo.GetAll().ToList();
                }
                else if (!_categoryRepo.ItemExists(categoryId))
                {
                    throw new Exception("Invalid category");
                }
                else
                {
                    products = _productRepo.GetAll().Where(a => a.CateogryId == categoryId).ToList();
                }
                allProducts = _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allProducts;


        }  
       public ProductDTO CreateProduct(ProductForCreationDTO productForCreation)
        {
            ProductDTO productDto;
            try
            {
                if (productForCreation == null)
                {
                    throw new ArgumentNullException(nameof(ProductService));
                }

                if (!_categoryRepo.ItemExists(productForCreation.CateogryId))
                {
                    throw new Exception("Invalid category");
                }
                var product = _mapper.Map<Product>(productForCreation);
                product = _productRepo.Insert(product);
                productDto = _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productDto;
        }

        public ProductDTO UpdateProduct(Guid productId, ProductForUpdateDTO productForUpdate)
        {
            ProductDTO productDto=null;
            try
            {
                var product = _productRepo.Get(productId);
                if(product==null)
                {
                    return null;
                }

                if (productForUpdate == null)
                {
                    throw new ArgumentNullException(nameof(ProductService));
                }
                product= _mapper.Map(productForUpdate,product);
                product = _productRepo.Update(product);
                productDto = _mapper.Map<ProductDTO>(product);

            }
            catch(Exception ex)
            {
                throw ex;
            }

            return  productDto;
        }
    }
}