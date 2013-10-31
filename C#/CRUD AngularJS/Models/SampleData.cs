using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace AngularJS_WebApi_EF.Models
{
    public class SampleData : DropCreateDatabaseAlways<PersonContext>
    {

        protected override void Seed(PersonContext context)
        {
            //base.Seed(context);
            var people = new List<Person>
                {
                    new Person {Name = "Jane", Email = "janedoe@gmail.com", Location= "Philadelphia"},
                    new Person {Name = "Jessica", Email = "jessicadoe@gmail.com", Location= "Los Angelas"},
                    new Person {Name = "Amy", Email = "amydoe@gmail.com", Location= "NYC"},
                    new Person {Name = "Christina", Email = "Christinadoe@gmail.com", Location= "Miami"}
                };

            people.ForEach(a => context.People.Add(a));
            context.SaveChanges();


            var items = new List<Item>
                {
                    new Item {Name = "Nike", Type = "shoe", Description = "awesome shoe", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "janedoe@gmail.com")},
                    new Item {Name = "Doce", Type = "shoe", Description = "pretty shoe", Size = "15", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "janedoe@gmail.com")},
                    new Item {Name = "Reebok", Type = "pumps", Description = "beautiful shoe", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "jessicadoe@gmail.com")},
                    new Item {Name = "Rockport", Type = "sneakers", Description = "cool  shoe", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "jessicadoe@gmail.com")},
                    new Item {Name = "Sketchers", Type = "sneakers", Description = "hiptser  shoe", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "amydoe@gmail.com")},
                    new Item {Name = "Lugz", Type = "boots", Description = "boots", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "Christinadoe@gmail.com")},
                    new Item {Name = "Very Cool Dress", Type = "dress", Description = "indie dress", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "Christinadoe@gmail.com")}
                };

            items.ForEach(a => context.Items.Add(a));
            context.SaveChanges();


            var comments = new List<Comment>
                {
                    new Comment { PersonID = people.Single(x => x.Email == "janedoe@gmail.com").Id,  CommentText = "This is crazy", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 1)},
                    new Comment { PersonID = people.Single(x => x.Email == "jessicadoe@gmail.com").Id,  CommentText = "This is awesome", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 1)},
                    new Comment { PersonID = people.Single(x => x.Email == "amydoe@gmail.com").Id,  CommentText = "This is hot", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 2)},
                    new Comment { PersonID = people.Single(x => x.Email == "Christinadoe@gmail.com").Id,  CommentText = "I love this", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 3)},
                    new Comment { PersonID = people.Single(x => x.Email == "Christinadoe@gmail.com").Id,  CommentText = "I want this!", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 4)}
                };

            comments.ForEach(a => context.Comments.Add(a));

            new List<Place>
                {
                    new Place {Name = "California"},
                    new Place {Name = "New Jersey"}
                }.ForEach(a => context.Places.Add(a));
        }

    }
}