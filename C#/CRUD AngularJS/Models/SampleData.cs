using System;
using System.Collections.Generic;
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
            new List<Place>
                {
                    new Place {Name = "California"},
                    new Place {Name = "New Jersey"}
                }.ForEach(a => context.Places.Add(a));
        }

    }
}