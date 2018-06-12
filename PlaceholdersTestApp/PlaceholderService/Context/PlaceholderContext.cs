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
        public List<User> Users { get; set; }
        public long UserId { get; set; }
    }
}
