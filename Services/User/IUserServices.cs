using Hiper.Commerce.Api.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Services.User
{
    public interface IUserServices
    {
        Task<Models.User> GetUserDataAsync(string email, string passWord);
        Task<UsersListModel> GetUsersAsync();
        Task<Models.User> DeleteUserByIdAsync(int id);
        Task<Models.User> SetUserAsync(Models.User user);
        Task<Models.User> UpdateUserAsync(Models.User userModel);
        Task<Models.User> ValidateUserAsync(Models.User usersModel);
        void ValidateEmailAndPasswordNullOrWhiteSpace(Models.User userModel);
        Task ValidateEmailRepeatedAsync(Models.User usersModel);
    }
}
