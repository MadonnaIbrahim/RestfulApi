using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Models
{
    public class ProductForManipulationDTO
    {
        [Required(ErrorMessage = "You should fill out the product name.")]
        [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out the product price.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "You should fill out the product quantity.")]
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        [Required(ErrorMessage = "You should add a category for the product.")]
        public Guid CateogryId { get; set; }
    }
}
