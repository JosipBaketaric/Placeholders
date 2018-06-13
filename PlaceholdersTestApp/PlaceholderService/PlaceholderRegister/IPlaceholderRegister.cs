using PlaceholderService.IPlaceholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.PlaceholderRegister
{
    public interface IPlaceholderRegister
    {
        string NamePlaceholder { get; }
        string LastNamePlaceholder { get; }
        string OIBPlaceholder { get; }
        string UserDataPlaceholder { get; }
    }
}
