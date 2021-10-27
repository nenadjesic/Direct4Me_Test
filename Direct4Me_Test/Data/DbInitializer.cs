using Direct4Me_Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Direct4Me_Test.Entities;

namespace Direct4Me_Test.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.DeliveryServices.Any())
            {
                return;   // DB has been seeded
            }


            var deliveris = new DeliveryService[]
            {
            new DeliveryService{Title="DPD",Code="1696"},
            new DeliveryService{Title="GLS",Code="GL"},
            new DeliveryService{Title="Posta",Code="PS"},
            new DeliveryService{Title="UPS",Code="UP"}

            };
            foreach (var d in deliveris)
            {
                context.DeliveryServices.Add(d);
            }
            context.SaveChanges();

        }
    }

}
