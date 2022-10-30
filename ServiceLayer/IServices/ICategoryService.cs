using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> getCategories();
    }
}
