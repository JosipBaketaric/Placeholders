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
    [Description("[[user_data_placeholder]]")]
    public class UserDataPlaceholder : IUserDataPlaceholder
    {
        private string _value;
        private long _userId;
        private INamePlaceholder _namePlaceholder;
        private ILastNamePlaceholder _lastNamePlaceholder;
        private IOIBPlaceholder _OIBPlaceholder;


        public UserDataPlaceholder(INamePlaceholder namePlaceholder, ILastNamePlaceholder lastNamePlaceholder, IOIBPlaceholder OIBPlaceholder)
        {
            _namePlaceholder = namePlaceholder;
            _lastNamePlaceholder = lastNamePlaceholder;
            _OIBPlaceholder = OIBPlaceholder;
        }
        public string GetValue(IPlaceholderContext placeholderContext, long userId)
        {
            if (!string.IsNullOrEmpty(this._value) && _userId == userId)
                return _value;


            _userId = userId;
            _value = "Name: " + _namePlaceholder.GetValue(placeholderContext, userId) + "  Last name: " + _lastNamePlaceholder.GetValue(placeholderContext, userId) + "   OIB: " + _OIBPlaceholder.GetValue(placeholderContext, userId);
            return _value;
        }
    }
}
