using PlaceholderService.IPlaceholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.PlaceholderFactory
{
    public interface IPlaceholderFactory
    {
        IPlaceholder GetOrCreatePlaceholder<T>() where T : IPlaceholder;
    }
}
