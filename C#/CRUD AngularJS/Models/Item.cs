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
        public string Type { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public int PriceList { get; set; }
        public int PriceLSale { get; set; }
        public List<Comment> Comments { get; set; }
        public Person Person { get; set; }
    }
}