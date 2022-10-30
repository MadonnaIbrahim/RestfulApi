using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"  example="categoryId">categoryId</param>
        /// <returns></returns>
        [HttpGet]
        [HttpHead]
        public ActionResult<CustomActionResult<List<ProductDTO>>> GetProducts([FromQuery] Guid categoryId)
        {
            ActionResult result;
            CustomActionResult<List<ProductDTO>> productsResult = new CustomActionResult<List<ProductDTO>>();
            try
            {
                productsResult.Result = _productService.GetProducts(categoryId).ToList();
                result = Ok(productsResult);
            }
            catch (Exception ex)
            {
                productsResult.Success = false;
                productsResult.Message = ex.Message;
                result = StatusCode(500, productsResult);
            }

            return result;
        }



        [HttpGet("{productId}", Name ="GetProduct")]
        public IActionResult GetProduct(Guid productId)
        {
            ActionResult result;
            CustomActionResult<ProductDTO> productResult = new CustomActionResult<ProductDTO>();

            try
            {
                ProductDTO product = _productService.GetProduct(productId);

                if (product == null)
                {
                    productResult.Success = false;
                    productResult.Message = "Item not found";
                    result = NotFound(productResult);
                }
                else
                {
                    productResult.Result = product;
                    result = Ok(productResult);
                }
            }
            catch (Exception ex)
            {
                productResult.Success = false;
                productResult.Message = ex.Message;
                result = StatusCode(500, ex.Message);
            }
            return result;
        }
        

        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct(ProductForCreationDTO productForCreation)
        {
            ActionResult result;
            CustomActionResult<ProductDTO> productResult = new CustomActionResult<ProductDTO>();

            try
            {
                if (!TryValidateModel(productForCreation))
                {

                    result=ValidationProblem(ModelState);
                }
                else
                {
                   var createdProduct= _productService.CreateProduct(productForCreation);
                    productResult.Result = createdProduct;
                    result = CreatedAtRoute("GetProduct",
                        new { productId = createdProduct.Id },productResult);
                }
            }
            catch(Exception ex)
            {
                productResult.Success = false;
                productResult.Message = ex.Message;
                result = StatusCode(500,productResult);
            }
            return result;
        }


        [HttpPut("{productId}")]
        public ActionResult<ProductDTO> UpdateProduct(Guid productId,[FromBody] ProductForUpdateDTO productForUpdate)
        {
            ActionResult result;
            CustomActionResult<ProductDTO> productResult = new CustomActionResult<ProductDTO>();

            try
            {
                if (!TryValidateModel(productForUpdate))
                {

                    result = ValidationProblem(ModelState);
                }
                else
                {
                    var updatedProduct = _productService.UpdateProduct(productId,productForUpdate);
                    productResult.Result = updatedProduct;
                    result = Ok(productResult);
                }
            }
            catch (Exception ex)
            {
                productResult.Success = false;
                productResult.Message = ex.Message;
                result = StatusCode(500, productResult);
            }
            return result;
        }
    }
}

