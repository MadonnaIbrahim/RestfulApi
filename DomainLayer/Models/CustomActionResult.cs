using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
  public  class CustomActionResult<T>
    {
        public bool Success { get; set; } = true;
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
