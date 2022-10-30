using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IServices
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProduct(Guid productId);
        List<ProductDTO> GetProducts(Guid categoryId);

        ProductDTO CreateProduct(ProductForCreationDTO productForCreation);
        ProductDTO UpdateProduct(Guid productId, ProductForUpdateDTO productForUpdate);

    }
}
