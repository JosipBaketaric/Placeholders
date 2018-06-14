using PlaceholderService.FakeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.Context
{
    public interface IPlaceholderContext
    {
        long UserId { get; set; }
        int DbCallsCounter { get; }
        List<User> Users { get; set; }
        List<Address> Addresses { get; set; }


    }
}
