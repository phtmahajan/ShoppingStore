using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class ProductCategory
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        
    }
}