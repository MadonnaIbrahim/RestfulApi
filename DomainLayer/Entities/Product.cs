using DomainLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities
{
    public class Product : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string ImgURL { get; set; }

        [ForeignKey("CateogryId")]
        public Category Category { get; set; }
        public Guid CateogryId { get; set; }
    }
}
