using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.FakeDB
{
    public class Address
    {
        public long Id { get; set; }
        public long userId { get; set; }
        public string AddressName { get; set; }
    }
}
