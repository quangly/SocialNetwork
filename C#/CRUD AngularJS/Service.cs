using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AngularJS_WebApi_EF.Models;

namespace AngularJS_WebApi_EF
{
    public class Service
    {
        private PersonContext db = new PersonContext();
        public IEnumerable<Object> GetPeople()
        {
            var comments = db.Comments.ToList();
            return db.People.Include(x => x.Items).OrderBy(x => x.Name).ToList()
                     .Select(x => new
                     {
                         Email = x.Email,
                         Id = x.Id,
                         Location = x.Location,
                         Name = x.Name,
                         UserName = x.UserName,
                         PicUrl = x.PicUrl,
                         Items = x.Items.Select(y => new
                         {
                             Comments = comments.Where(z => z.Item == y).OrderByDescending(z => z.InsertDT).Select(z => new
                             {
                                 CommentText = z.CommentText,
                                 Name = z.Person.Name,
                                 UserName = z.Person.UserName,
                                 PicUrl = z.Person.PicUrl
                             }).ToList(),//.Take(1)
                             Description = y.Description,
                             Id = y.Id,
                             Name = y.Name,
                             PriceList = y.PriceList,
                             PriceLSale = y.PriceLSale,
                             Size = y.Size,
                             Type = y.Size,
                             PicUrl = y.PicUrl
                         }).ToList()//.Take(1)
                     }).AsEnumerable();
        }

        public object GetUser(string username)
        {
            var person =
                GetPeople().FirstOrDefault(x => x.GetType().GetProperty("UserName").GetValue(x, null).ToString() == username);
            return person;  
        }

        public object Search(string username)
        {
            var person = (!String.IsNullOrEmpty(username) && username != "undefined") ? GetPeople().Where(x => x.GetType().GetProperty("UserName").GetValue(x, null).ToString().Contains(username)) : GetPeople();
            return person;
        }

        public object PostComment(CommentPost commentPost)
        {
            if (!String.IsNullOrEmpty(commentPost.commentText) && !string.IsNullOrEmpty(commentPost.userName))
            {

                Comment comment = new Comment();
                comment.CommentText = commentPost.commentText;
                comment.Item = db.Items.FirstOrDefault(x => x.Id == commentPost.itemId);
                comment.Person = db.People.FirstOrDefault(x => x.UserName == commentPost.userName);
                comment.InsertDT = DateTime.Now;

                db.Comments.Add(comment);
                db.SaveChanges();

                return new { Success = true, Message = "Commented posted." };
            }
            else
            {
                return new { Success = false, Message = "Comment failed" };
            }            
        }

    }
}