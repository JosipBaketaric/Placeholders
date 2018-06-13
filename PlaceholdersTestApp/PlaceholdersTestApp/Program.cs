using PlaceholderService.Context;
using PlaceholderService.FakeDB;
using PlaceholderService.PlaceholderRegister;
using PlaceholderService.PlaceholderFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> fakeDB = new List<User>
            {
                new User{ ID = 1, Name = "Miro", LastName = "Mirić", OIB = "12121212-1" },
                new User{ ID = 2, Name = "Miro2", LastName = "Mirić2", OIB = "12121212-2" },
                new User{ ID = 3, Name = "Miro3", LastName = "Mirić3", OIB = "12121212-3" },
                new User{ ID = 4, Name = "Miro4", LastName = "Mirić4", OIB = "12121212-4" },
                new User{ ID = 5, Name = "Miro5", LastName = "Mirić5", OIB = "12121212-5" },
            };
            IPlaceholderContext placeholderContext = new PlaceholderContext();
            //set data
            placeholderContext.UserId = 1;
            placeholderContext.Users = fakeDB;

            IPlaceholderFactory placeholderFactory = new PlaceholderFactory();
            IPlaceholderRegister placeholderRegister = new PlaceholderRegister(placeholderContext, placeholderFactory);
            Console.WriteLine("lastName: " + placeholderRegister.LastNamePlaceholder);

            Console.WriteLine("UserDataPlaceholder: " + placeholderRegister.UserDataPlaceholder);
            Console.WriteLine("Name: " + placeholderRegister.NamePlaceholder);
            Console.WriteLine("OIB: " + placeholderRegister.OIBPlaceholder);

            Console.WriteLine("DB CALLS: " + placeholderContext.DbCallsCounter);


            Console.ReadKey();
        }
    }
}
