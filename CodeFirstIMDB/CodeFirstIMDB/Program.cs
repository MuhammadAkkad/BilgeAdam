using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace CodeFirstIMDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
            var destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            Console.ReadLine();
                        }
                    }
                }

            }


            var trip = new Trip
            {
                CostUSD = 800,
                StartDate = new DateTime(2011, 9, 1),
                EndDate = new DateTime(2011, 9, 14)
            };
            using (var context = new BreakAwayContext())
            {
                context.Trips.Add(trip);

                try
                {
                  context.SaveChanges();
                }

                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            Console.ReadLine();
                        }
                    }
                }
            }

            // update trip
            using (var context = new BreakAwayContext())
            {
                var trip2 = context.Trips.FirstOrDefault();
                trip2.CostUSD = 750;
                context.SaveChanges();
            }


            var person = new Person
            {
                FirstName = "Rowan",
                LastName = "Miller",
                SocialSecurityNumber = 12345678
            };
            using (var context = new BreakAwayContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }
    }
}
