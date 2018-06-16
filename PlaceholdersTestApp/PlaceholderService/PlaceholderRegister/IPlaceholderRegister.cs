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

        string GetNamePlaceholder(long userId);

        string GetLastNamePlaceholder(long userId);

        string GetOIBPlaceholder(long userId);

        string GetUserDataPlaceholder(long userId);

        string GetAdressPlaceholder(long userId);

    }
}
