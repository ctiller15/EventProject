namespace EventProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EventProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EventProject.Data.EventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventProject.Data.EventContext db)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // CITIES
            var cities = new List<City>
            {
                new City { Name = "PROBurg" },
                new City { Name = "Twilight Town" },
                new City { Name = "Dunbarton" },
                new City { Name = "Varrock" },
                new City { Name = "Goldenrod City" }
            };

            // EVENTS
            var events = new List<Event>
            {
                new Event
                {
                    Title = "Code Katas!!!",
                    Tagline = "Polish your code skills!",
                    Long_Description = "An event where friends who like coding do some coding stuff.",
                    Address = "12345 You noPark blvd",
                    CityID = 1,
                    State = "FL",
                    Zip = "33909",
                    Age_Limit = 70,
                    Price = 0.00m,
                    DateHappening = new DateTime(2018, 06, 20)
                },
                new Event
                {
                    Title = "Fun Run!",
                    Tagline = "Come out, run and get fit.",
                    Long_Description = "A fun running event.",
                    Address = "512 No parkinghere st",
                    CityID = 1,
                    State = "FL",
                    Zip = "33555",
                    Age_Limit = 70,
                    Price = 50.00m,
                    DateHappening = new DateTime(2018, 07, 14)
                },
                new Event
                {
                    Title = "Movie Viewing",
                    Tagline = "Come have some good food and some fun movies!",
                    Long_Description = "A biweekly event where we all get together at a restaurant and watch a movie. Duh!",
                    Address = "900 we wantyourmoney circle",
                    CityID = 1,
                    State = "FL",
                    Zip = "32105",
                    Age_Limit = 40,
                    Price = 10.00m,
                    DateHappening = new DateTime(2018, 05, 10)
                },
                new Event
                {
                    Title = "Language meetup",
                    Tagline = "Get to know your community members and improve your language skills",
                    Long_Description = "An event where friends who like coding do some coding stuff.",
                    Address = "12000 SomeonesHome circle",
                    CityID = 1,
                    State = "FL",
                    Zip = "33909",
                    Age_Limit = 70,
                    Price = 0.00m,
                    DateHappening = new DateTime(2018, 08, 29)
                },
                new Event
                {
                    Title = "Doggy playtime",
                    Tagline = "A fun day in the park",
                    Long_Description = "An event where friends who like coding do some coding stuff.",
                    Address = "500 DontTrustOurDogs lane",
                    CityID = 1,
                    State = "FL",
                    Zip = "32780",
                    Age_Limit = 90,
                    Price = 0.00m,
                    DateHappening = new DateTime(2019, 01, 01)
                },

            };

            // ATTENDEES
            var attendees = new List<Attendee>()
            {
                new Attendee(){ Email = "myEmail@email.com" },
                new Attendee(){ Email = "FakeEmail@email.com" },
                new Attendee(){ Email = "IWishIwasARealBoy@email.com" },
                new Attendee(){ Email = "IChangedALetter@gmail.com" },
                new Attendee(){ Email = "SK8RBOYOFDARKNESS@Yahoo.com" },
                new Attendee(){ Email = "XXxxImAnEdgyTeenxxXX.@crapdomaincom" },
                new Attendee(){ Email = "ImAresponsibleAdult@hotmail.com" },
                new Attendee(){ Email = "FirstNameLastName1993@thisworks.com" },
                new Attendee(){ Email = "ImAnotherEmailChrisHadToInsert@gmail.com" },
                new Attendee(){ Email = "DogsAreAwesome@dogster.org" },
                new Attendee(){ Email = "SuperProfessional@professionalprofessions.net" },
            };

            cities.ForEach(city =>
            {
                db.Cities.AddOrUpdate(c => c.Name, city);
            });

            events.ForEach(cityEvent =>
            {
                db.Events.AddOrUpdate(e => e.Title, cityEvent);
            });

            attendees.ForEach(attendee =>
            {
                db.Attendees.AddOrUpdate(a => a.Email, attendee);
            });

            db.SaveChanges();

        }
    }
}
