using DomainLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

      
        [HttpGet]
        [HttpHead]
        public ActionResult<CustomActionResult<List<CategoryDTO>>> GetCategories()
        {
            ActionResult result;
            CustomActionResult<List<CategoryDTO>> categoriesResult = new CustomActionResult<List<CategoryDTO>>();
            try
            {
                categoriesResult.Result = _categoryService.getCategories().ToList();
                result = Ok(categoriesResult);
            }
            catch(Exception ex) {
                categoriesResult.Success = false;
                categoriesResult.Message = ex.Message;
                result = StatusCode(500, ex.Message);
            }

            return result;
            }

    }
}
