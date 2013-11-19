using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace AngularJS_WebApi_EF.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<PersonContext>
    {

        protected override void Seed(PersonContext context)
        {
            //base.Seed(context);
            var people = new List<Person>
                {
                    new Person {UserName = "jane123", Name = "Jane", Email = "janedoe@gmail.com", Location= "Philadelphia", PicUrl="/Content/photos/person/jane.jpg"},
                    new Person {UserName = "jessica123", Name = "Jessica", Email = "jessicadoe@gmail.com", Location= "Los Angelas", PicUrl="/Content/photos/person/jessica.jpg"},
                    new Person {UserName = "amy123",  Name ="Amy", Email = "amydoe@gmail.com", Location= "NYC", PicUrl="/Content/photos/person/amy.jpg"},
                    new Person {UserName = "christina123", Name = "Christina", Email = "Christinadoe@gmail.com", Location= "Miami",PicUrl="/Content/photos/person/christina.jpg"},
                    new Person {UserName = "deltadreams", Name = "Quang", Email = "quangdly@gmail.com", Location= "Miami",PicUrl="/Content/photos/person/quang.jpg"}
                };

            people.ForEach(a => context.People.Add(a));
            context.SaveChanges();


            var items = new List<Item>
                {
                    new Item {Name = "Purple", Type = "shoe", PicUrl="/Content/photos/items/1.jpg", Description = "high fashion", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "janedoe@gmail.com")},
                    new Item {Name = "Cute Red", Type = "shoe", PicUrl="/Content/photos/items/2.jpg",Description = "my favorite", Size = "15", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "janedoe@gmail.com")},
                    new Item {Name = "Red Pumps", Type = "pumps", PicUrl="/Content/photos/items/3.jpg",Description = "jaw droppers", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "jessicadoe@gmail.com")},
                    new Item {Name = "Sexy Dress", Type = "sneakers",PicUrl="/Content/photos/items/4.jpg", Description = "late night comfort", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "jessicadoe@gmail.com")},
                    new Item {Name = "Striped Shirt", Type = "sneakers", PicUrl="/Content/photos/items/5.jpg",Description = "hiptser  ouitfit", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "amydoe@gmail.com")},
                    new Item {Name = "My fav shoes", Type = "boots", PicUrl="/Content/photos/items/6.jpg",Description = "boots", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "Christinadoe@gmail.com")},
                    new Item {Name = "My stilettos", Type = "dress",PicUrl="/Content/photos/items/7.jpg",  Description = "dangerous shoes", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "Christinadoe@gmail.com")},
                    new Item {Name = "Red rain jacket", Type = "dress",PicUrl="/Content/photos/items/8.jpg",  Description = "", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "amydoe@gmail.com")},
                    new Item {Name = "Blue shirt", Type = "dress",PicUrl="/Content/photos/items/9.jpg",  Description = "casual fit", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "amydoe@gmail.com")},
                    new Item {Name = "Golden slippers", Type = "shoes",PicUrl="/Content/photos/items/10.jpg",  Description = "casual fit", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "amydoe@gmail.com")},
                    new Item {Name = "turntable", Type = "turntable",PicUrl="/Content/photos/items/11.jpg",  Description = "turn table", Size = "5", PriceList = 100, PriceLSale = 50, Person = people.Single(a => a.Email == "quangdly@gmail.com")}
                };

            items.ForEach(a => context.Items.Add(a));
            context.SaveChanges();


            var comments = new List<Comment>
                {
                    new Comment { Person = people.Single(x => x.Email == "janedoe@gmail.com"),  CommentText = "This is crazy", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 1)},
                    new Comment { Person = people.Single(x => x.Email == "jessicadoe@gmail.com"),  CommentText = "This is awesome", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 1)},
                    new Comment { Person = people.Single(x => x.Email == "amydoe@gmail.com"),  CommentText = "This is hot", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 2)},
                    new Comment { Person = people.Single(x => x.Email == "Christinadoe@gmail.com"),  CommentText = "I love this", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 3)},
                    new Comment { Person = people.Single(x => x.Email == "Christinadoe@gmail.com"),  CommentText = "I want this!", InsertDT = DateTime.Now, Item = items.Single(x=> x.Id == 4)}
                };

            comments.ForEach(a => context.Comments.Add(a));
            context.SaveChanges();

            new List<Place>
                {
                    new Place {Name = "California"},
                    new Place {Name = "New Jersey"}
                }.ForEach(a => context.Places.Add(a));
        }

    }
}