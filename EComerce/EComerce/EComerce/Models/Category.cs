﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Models
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<Product> Products { get; set; }

    }
}
