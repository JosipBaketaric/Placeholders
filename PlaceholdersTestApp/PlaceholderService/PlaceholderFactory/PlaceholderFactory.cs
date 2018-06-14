using PlaceholderService.IPlaceholders;
using PlaceholderService.Placeholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderService.PlaceholderFactory
{
    public class PlaceholderFactory : IPlaceholderFactory
    {
        private Dictionary<Type, IPlaceholder> placeholders;
        public PlaceholderFactory()
        {
            placeholders = new Dictionary<Type, IPlaceholder>();
        }
        public IPlaceholder GetOrCreatePlaceholder<T>() where T : IPlaceholder
        {
            Type type = typeof(T);
            IPlaceholder placeholder;


            if (type == typeof(INamePlaceholder))
            {
                if (!placeholders.TryGetValue(type, out placeholder))
                {
                    placeholder = new NamePlaceholder();

                }
            }

            else if (type == typeof(ILastNamePlaceholder))
            {
                if (!placeholders.TryGetValue(type, out placeholder))
                {
                    placeholder = new LastNamePlaceholder();
                }
            }

            else if(type == typeof(IOIBPlaceholder))
            {
                if (!placeholders.TryGetValue(type, out placeholder))
                {
                    placeholder = new OIBPlaceholder();
                }

            }
            else if (type == typeof(IAdressPlaceholder))
            {
                if (!placeholders.TryGetValue(type, out placeholder))
                {
                    placeholder = new AdressPlaceholder();
                }

            }
            else if(type == typeof(IUserDataPlaceholder))
            {
                if (!placeholders.TryGetValue(type, out placeholder))
                {
                    var namePlaceholder = (INamePlaceholder)GetOrCreatePlaceholder<INamePlaceholder>();
                    var lastNamePlaceholder = (ILastNamePlaceholder)GetOrCreatePlaceholder<ILastNamePlaceholder>();
                    var oibPlaceholder = (IOIBPlaceholder)GetOrCreatePlaceholder<IOIBPlaceholder>();
                    placeholder = new UserDataPlaceholder(namePlaceholder, lastNamePlaceholder, oibPlaceholder);
                }
            }
            else
            {
                throw new Exception("Invalid placeholder. Placeholder missing in GetOrCreate method of PlaceholderBuilder.");
            }



            if (!placeholders.ContainsKey(type))
            {
                placeholders.Add(type, placeholder);
            }
            return placeholder;
        }

    }
}
