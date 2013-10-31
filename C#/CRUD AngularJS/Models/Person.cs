using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string PicUrl { get; set; }
        public List<Item> Items { get; set; }
        
    }
}