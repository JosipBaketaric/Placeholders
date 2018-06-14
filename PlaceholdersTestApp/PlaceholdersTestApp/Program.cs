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
            IPlaceholderContext placeholderContext = new PlaceholderContext();

            List<User> fakeDB = new List<User>
            {
                new User{ ID = 1, Name = "Miro", LastName = "Mirić", OIB = "12121212-1" },
                new User{ ID = 2, Name = "Miro2", LastName = "Mirić2", OIB = "12121212-2" },
                new User{ ID = 3, Name = "Miro3", LastName = "Mirić3", OIB = "12121212-3" },
                new User{ ID = 4, Name = "Miro4", LastName = "Mirić4", OIB = "12121212-4" },
                new User{ ID = 5, Name = "Miro5", LastName = "Mirić5", OIB = "12121212-5" },
            };
            List<Address> fakeAdress = new List<Address>
            {
                new Address{ Id = 1, AddressName="a1", userId = 1 },
                new Address{ Id = 2, AddressName="a2", userId = 1 },
                new Address{ Id = 3, AddressName="a3", userId = 2 },
                new Address{ Id = 4, AddressName="a4", userId = 2 },
                new Address{ Id = 5, AddressName="a5", userId = 3 },
            };

            //set data
            placeholderContext.UserId = 1;
            placeholderContext.Users = fakeDB;
            placeholderContext.Addresses = fakeAdress;



            IPlaceholderFactory placeholderFactory = new PlaceholderFactory();
            IPlaceholderRegister placeholderRegister = new PlaceholderRegister(placeholderContext, placeholderFactory);
            Console.WriteLine("lastName: " + placeholderRegister.GetLastNamePlaceholder(placeholderContext.UserId));

            Console.WriteLine("UserDataPlaceholder: " + placeholderRegister.GetUserDataPlaceholder(placeholderContext.UserId));
            Console.WriteLine("Name: " + placeholderRegister.GetNamePlaceholder(placeholderContext.UserId));
            Console.WriteLine("OIB: " + placeholderRegister.GetOIBPlaceholder(placeholderContext.UserId));
            Console.WriteLine("ADRESS PLACEHOLDER: \n" + placeholderRegister.GetAdressPlaceholder(placeholderContext.UserId));



            Console.WriteLine("DB CALLS: " + placeholderContext.DbCallsCounter);


            Console.ReadKey();
        }
    }
}
