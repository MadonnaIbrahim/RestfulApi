using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Entities
{
    public class Category : BaseEntity
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
    }
}
