using PlaceholderService.IPlaceholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.Context;

namespace PlaceholderService.Placeholders
{
    public class AdressPlaceholder : IAdressPlaceholder
    {
        private string _value;
        private long _userId;
        public string GetValue(IPlaceholderContext placeholderContext, long userId)
        {
            if (!string.IsNullOrEmpty(this._value) && _userId == userId)
                return _value;

            _userId = userId;
            var tempResult = placeholderContext.Addresses.Where(x => x.userId == userId).Select(x => x.AddressName).ToList();

            for(int i = 0; i < tempResult.Count; i++)
            {
                _value += "Adress " + (i + 1) + ": " + tempResult.ElementAt(i) + ",\n";
            }

            return _value;
        }
    }
}
