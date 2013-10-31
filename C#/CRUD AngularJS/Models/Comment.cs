using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public int PersonID { get; set; }
        public string CommentText { get; set; }
        public DateTime InsertDT { get; set; }

        public Item Item { get; set; }
        //public Person Person { get; set; }
    }
}