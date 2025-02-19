using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Book
    {
  
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        
        public string Description { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public string DetailsDescription { get; set; }
        public string DetailsImage { get; set; }
    }
}