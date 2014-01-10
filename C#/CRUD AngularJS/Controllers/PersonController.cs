using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AngularJS_WebApi_EF.Models;

namespace AngularJS_WebApi_EF.Controllers
{
    public class PersonController : ApiController
    {
        private PersonContext db = new PersonContext();

        [HttpGet]
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
                                     Comments = comments.Where(z => z.Item == y).OrderByDescending(z =>z.InsertDT).Select(z => new
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

        [HttpGet]
        public object GetUser(string username)
        {
            var person =
                GetPeople().FirstOrDefault(x => x.GetType().GetProperty("UserName").GetValue(x, null).ToString() == username);
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return person;            
        }

        [HttpGet]
        public object Search(string username)
        {

            var person = (!String.IsNullOrEmpty(username) && username != "undefined") ? GetPeople().Where(x => x.GetType().GetProperty("UserName").GetValue(x, null).ToString().Contains(username)) : GetPeople();
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return person;
        }


        [HttpPost]
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

                return new {Success = true};
            }
            else
            {
                return new { Success = false, Message="XX" };
            }
        }

        
        // GET api/Person/5
        public Person GetPerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return person;
        }

        // PUT api/Person/5
        public HttpResponseMessage PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != person.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Person
        public HttpResponseMessage PostPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, person);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = person.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Person/5
        public HttpResponseMessage DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.People.Remove(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}