using PlaceholderService.IPlaceholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.Context;

namespace PlaceholderService.Placeholders
{
    public class UserDataPlaceholder : IUserDataPlaceholder
    {
        private string _value;
        private long _id;
        private INamePlaceholder _namePlaceholder;
        private ILastNamePlaceholder _lastNamePlaceholder;
        private IOIBPlaceholder _OIBPlaceholder;
        public UserDataPlaceholder(INamePlaceholder namePlaceholder, ILastNamePlaceholder lastNamePlaceholder, IOIBPlaceholder OIBPlaceholder)
        {
            _namePlaceholder = namePlaceholder;
            _lastNamePlaceholder = lastNamePlaceholder;
            _OIBPlaceholder = OIBPlaceholder;
        }
        public string GetValue(IPlaceholderContext placeholderContext)
        {
            if (!string.IsNullOrEmpty(this._value) && _id == placeholderContext.UserId)
                return _value;


            _id = placeholderContext.UserId;
            _value = "Name: " + _namePlaceholder.GetValue(placeholderContext) + "  Last name: " + _lastNamePlaceholder.GetValue(placeholderContext) + "   OIB: " + _OIBPlaceholder.GetValue(placeholderContext);
            return _value;
        }
    }
}
