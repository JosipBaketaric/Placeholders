using PlaceholderService.IPlaceholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.Context;

namespace PlaceholderService.Placeholders
{
    public class LastNamePlaceholder : ILastNamePlaceholder
    {
        private string _value;
        private long _id;
        public string GetValue(IPlaceholderContext placeholderContext)
        {
            if (!string.IsNullOrEmpty(this._value) && _id == placeholderContext.UserId)
                return _value;

            _id = placeholderContext.UserId;
            _value = placeholderContext.Users.Where(x => x.ID == placeholderContext.UserId).Select(x => x.LastName).FirstOrDefault();
            return _value;
        }
    }
}
