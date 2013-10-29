using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Size { get; set; }
        public decimal PriceList { get; set; }
        public decimal PriceLSale { get; set; }
        public List<Comment> Comments { get; set; }
        public Person Person { get; set; }
    }
}