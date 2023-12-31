﻿using System.ComponentModel.DataAnnotations;

namespace ProducerServices.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
