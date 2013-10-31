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

        // GET api/Person
        public IEnumerable<Person> GetPeople()
        {
            return db.People.Include(x => x.Items).ToList()
                .Select(x => new Person()
                {
                    Comments = x.Comments,
                    Email = x.Email,
                    Id = x.Id,
                    Location = x.Location,
                    Name = x.Name,
                    PicUrl = x.PicUrl,
                    Items = x.Items.Select(y => new Item()
                        {
                            Comments = y.Comments,
                            Description = y.Description,
                            Id = y.Id,
                            Name = y.Name,
                            PriceList = y.PriceList,
                            PriceLSale = y.PriceLSale,
                            Size = y.Size,
                            Type = y.Size,
                            Person = null
                        }).ToList()
                }).AsEnumerable();
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