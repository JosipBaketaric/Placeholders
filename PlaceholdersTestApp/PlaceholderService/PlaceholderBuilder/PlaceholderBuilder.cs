using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.IPlaceholders;
using PlaceholderService.Context;
using PlaceholderService.Placeholders;

namespace PlaceholderService.PlaceholderBuilder
{
    public class PlaceholderBuilder : IPlaceholderBuilder
    {
        private IPlaceholderContext _placeholderContext;
        private Dictionary<Type, IPlaceholder> placeholders;
        public PlaceholderBuilder(IPlaceholderContext placeholderContext)
        {
            _placeholderContext = placeholderContext;
            placeholders = new Dictionary<Type, IPlaceholder>();
        }

        private IPlaceholder GetOrCreatePlaceholder<T>() where T : IPlaceholder
        {
            Type type = typeof(T);

            if(type == typeof(INamePlaceholder))
            {
                IPlaceholder placeholder;
                if (placeholders.TryGetValue(type, out placeholder))
                {
                    return placeholder;
                }
                else
                {
                    placeholder = new NamePlaceholder();
                }
                return placeholder;
            }

            if (type == typeof(ILastNamePlaceholder))
            {
                IPlaceholder placeholder;
                if (placeholders.TryGetValue(type, out placeholder))
                {
                    return placeholder;
                }
                else
                {
                    placeholder = new LastNamePlaceholder();
                }
                return placeholder;
            }

            if (type == typeof(IOIBPlaceholder))
            {
                IPlaceholder placeholder;
                if (placeholders.TryGetValue(type, out placeholder))
                {
                    return placeholder;
                }
                else
                {
                    placeholder = new OIBPlaceholder();
                }
                return placeholder;
            }
            if (type == typeof(IUserDataPlaceholder))
            {
                IPlaceholder placeholder;
                if (placeholders.TryGetValue(type, out placeholder))
                {
                    return placeholder;
                }
                else
                {
                    var namePlaceholder = (INamePlaceholder)GetOrCreatePlaceholder<INamePlaceholder>();
                    var lastNamePlaceholder = (ILastNamePlaceholder)GetOrCreatePlaceholder<ILastNamePlaceholder>();
                    var oibPlaceholder = (IOIBPlaceholder)GetOrCreatePlaceholder<IOIBPlaceholder>();

                    placeholder = new UserDataPlaceholder(namePlaceholder, lastNamePlaceholder, oibPlaceholder);
                }
                return placeholder;
            }
            throw new Exception("Invalid placeholder. Placeholder missing in GetOrCreate method of PlaceholderBuilder.");
        }

        public string NamePlaceholder
        {
            get
            {
                return GetOrCreatePlaceholder<INamePlaceholder>().GetValue(_placeholderContext);
            }
        }
        public string LastNamePlaceholder
        {
            get
            {
                return GetOrCreatePlaceholder<ILastNamePlaceholder>().GetValue(_placeholderContext);
            }
        }
        public string OIBPlaceholder
        {
            get
            {
                return GetOrCreatePlaceholder<IOIBPlaceholder>().GetValue(_placeholderContext);
            }
        }
        public string UserDataPlaceholder
        {
            get
            {
                return GetOrCreatePlaceholder<IUserDataPlaceholder>().GetValue(_placeholderContext);
            }
        }
    }
}
