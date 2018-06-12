using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaceholderService.IPlaceholders;
using PlaceholderService.Context;
using PlaceholderService.Placeholders;
using PlaceholderService.PlaceholderFactory;

namespace PlaceholderService.PlaceholderBuilder
{
    public class PlaceholderBuilder : IPlaceholderBuilder
    {
        private IPlaceholderContext _placeholderContext;
        private IPlaceholderFactory _placeholderFactory;
        public PlaceholderBuilder(IPlaceholderContext placeholderContext, IPlaceholderFactory placeholderFactory)
        {
            _placeholderContext = placeholderContext;
            _placeholderFactory = placeholderFactory;
        }


        #region Placeholder getters
        public string NamePlaceholder
        {
            get
            {
                return _placeholderFactory.GetOrCreatePlaceholder<INamePlaceholder>().GetValue(_placeholderContext);
            }
        }
        public string LastNamePlaceholder
        {
            get
            {
                return _placeholderFactory.GetOrCreatePlaceholder<ILastNamePlaceholder>().GetValue(_placeholderContext);
            }
        }
        public string OIBPlaceholder
        {
            get
            {
                return _placeholderFactory.GetOrCreatePlaceholder<IOIBPlaceholder>().GetValue(_placeholderContext);
            }
        }
        public string UserDataPlaceholder
        {
            get
            {
                return _placeholderFactory.GetOrCreatePlaceholder<IUserDataPlaceholder>().GetValue(_placeholderContext);
            }
        }
        #endregion
    }
}
