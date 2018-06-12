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
        public int DbCallsCounter { get; private set; }

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
        public long UserId { get; set; }
    }
}
