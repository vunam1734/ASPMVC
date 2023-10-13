﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Product
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        public string Description { set; get; }
        [Required]
        public double Price { set; get; }
        public int CategoryId { set; get; }
        [ForeignKey("CategoryId")]
        public Category Category { set; get; }
        public string ImageUrl { set; get; }
    }
}
