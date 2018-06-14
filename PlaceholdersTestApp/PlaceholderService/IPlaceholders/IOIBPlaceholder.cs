using PlaceholderService.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.IPlaceholders
{
    public interface IOIBPlaceholder : IPlaceholder
    {
        string GetValue(IPlaceholderContext placeholderContext, long userId);

    }
}
