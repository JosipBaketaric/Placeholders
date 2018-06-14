using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.IPlaceholders;
using PlaceholderService.Context;
using PlaceholderService.Placeholders;
using PlaceholderService.PlaceholderFactory;

namespace PlaceholderService.PlaceholderRegister
{
    public class PlaceholderRegister : IPlaceholderRegister
    {
        private IPlaceholderContext _placeholderContext;
        private IPlaceholderFactory _placeholderFactory;
        public PlaceholderRegister(IPlaceholderContext placeholderContext, IPlaceholderFactory placeholderFactory)
        {
            _placeholderContext = placeholderContext;
            _placeholderFactory = placeholderFactory;
        }


        #region Placeholder getters
        public string GetNamePlaceholder(long userId)
        {
            return (_placeholderFactory.GetOrCreatePlaceholder<INamePlaceholder>() as INamePlaceholder).GetValue(_placeholderContext, userId);
        }
        public string GetLastNamePlaceholder(long userId)
        {
            return (_placeholderFactory.GetOrCreatePlaceholder<ILastNamePlaceholder>() as ILastNamePlaceholder).GetValue(_placeholderContext, userId);
        }
        public string GetOIBPlaceholder(long userId)
        {
            return (_placeholderFactory.GetOrCreatePlaceholder<IOIBPlaceholder>() as IOIBPlaceholder).GetValue(_placeholderContext, userId);

        }
        public string GetUserDataPlaceholder(long userId)
        {
            return (_placeholderFactory.GetOrCreatePlaceholder<IUserDataPlaceholder>() as IUserDataPlaceholder).GetValue(_placeholderContext, userId);
        }
        public string GetAdressPlaceholder(long userId)
        {
            return (_placeholderFactory.GetOrCreatePlaceholder<IAdressPlaceholder>() as IAdressPlaceholder).GetValue(_placeholderContext, userId);
        }


        #endregion
    }
}
