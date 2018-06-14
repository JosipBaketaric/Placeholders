using PlaceholderService.FakeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.Context
{
    public class PlaceholderContext : IPlaceholderContext
    {
        private List<User> _users;
        private List<Address> _adresses;
        public int DbCallsCounter { get; private set; }
        public long UserId { get; set; }

        public List<User> Users
        {
            get
            {
                DbCallsCounter++;
                return _users;
            }
            set
            {
                _users = value;
            }
        }
        public List<Address> Addresses
        {
            get
            {
                DbCallsCounter++;
                return _adresses;
            }
            set
            {
                _adresses = value;
            }
        }

    }
}
