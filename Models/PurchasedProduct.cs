using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class PurchasedProduct
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        public string LongDesc { get; set; }
        public string DescImg { get; set; }

    }
}