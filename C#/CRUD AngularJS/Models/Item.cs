using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Models
{
    public class Item
    {
        [Key]

        public int Id { get; set; }
        public int PersonID { get; set; }
        public decimal PriceList { get; set; }
        public decimal PriceLSale { get; set; }


    }
}