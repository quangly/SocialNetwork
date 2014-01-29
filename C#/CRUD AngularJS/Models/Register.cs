using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Models
{
    public class Register
    {

        public string userName { get; set; }
        public string name { get; set; }
        public string email{ get; set; }
        public string location { get; set; }
        public string picUrl { get; set; }

    }
}