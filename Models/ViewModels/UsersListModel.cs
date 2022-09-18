using Hiper.Commerce.Api.ViewModels.Base;
using System.Collections.Generic;

namespace Hiper.Commerce.Api.Models.ViewModels
{
    public class UsersListModel : BaseViewModel
    {
        public IList<Models.User> Users { get; set; }
    }
}
