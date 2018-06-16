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
            IPlaceholderFactory placeholderFactory = new PlaceholderFactory();
            IPlaceholderRegister placeholderRegister = new PlaceholderRegister(placeholderContext, placeholderFactory);

            List<User> fakeUserTable = new List<User>
            {
                new User{ Id = 1, Name = "Miro", LastName = "Mirić", OIB = "12121212-1" },
                new User{ Id = 2, Name = "Miro2", LastName = "Mirić2", OIB = "12121212-2" },
                new User{ Id = 3, Name = "Miro3", LastName = "Mirić3", OIB = "12121212-3" },
                new User{ Id = 4, Name = "Miro4", LastName = "Mirić4", OIB = "12121212-4" },
                new User{ Id = 5, Name = "Miro5", LastName = "Mirić5", OIB = "12121212-5" },
            };
            List<Address> fakeAdressTable = new List<Address>
            {
                new Address{ Id = 1, AddressName="a1", userId = 1 },
                new Address{ Id = 2, AddressName="a2", userId = 1 },
                new Address{ Id = 3, AddressName="a3", userId = 2 },
                new Address{ Id = 4, AddressName="a4", userId = 2 },
                new Address{ Id = 5, AddressName="a5", userId = 3 },
            };

            //set data
            placeholderContext.UserId = 1;
            placeholderContext.Users = fakeUserTable;
            placeholderContext.Addresses = fakeAdressTable;



            //All replacing should be specified here
            //Problem: possibly to many data 

            string testInput = "I am [[last_name_placeholder]], [[name_placeholder]] [[last_name_placeholder]].";

            testInput = testInput.Replace("[[name_placeholder]]", placeholderRegister.GetNamePlaceholder(placeholderContext.UserId));
            testInput = testInput.Replace("[[last_name_placeholder]]", placeholderRegister.GetLastNamePlaceholder(placeholderContext.UserId));
            testInput = testInput.Replace("[[oib_placeholder]]", placeholderRegister.GetOIBPlaceholder(placeholderContext.UserId));


            Console.WriteLine(testInput);

            Console.ReadKey();
        }
    }
}
