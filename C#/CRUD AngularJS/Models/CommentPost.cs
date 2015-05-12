using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Models
{
    public class CommentPost
    {
        public int itemId { get; set; }
        public string commentText { get; set; }
        public string userName{ get; set; }
        


    }
}