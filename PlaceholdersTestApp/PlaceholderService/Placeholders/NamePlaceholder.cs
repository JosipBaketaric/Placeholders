﻿using PlaceholderService.IPlaceholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.Context;
using System.ComponentModel;

namespace PlaceholderService.Placeholders
{
    [Description("[[name_placeholder]]")]
    public class NamePlaceholder : INamePlaceholder
    {
        private string _value;
        private long _userId;


        public string GetValue(IPlaceholderContext placeholderContext, long userId)
        {
            if (!string.IsNullOrEmpty(this._value) && _userId == userId)
                return _value;

            _userId = userId;
            _value = placeholderContext.Users.Where(x => x.Id == userId).Select(x => x.Name).FirstOrDefault();
            return _value;
        }

    }
}
