using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Repositories.User
{
    public interface IUserRepository
    {
        Task<Models.User> GetUserByEmailAsync(string email);
        Task<Models.User> GetUserByIdAsync(int id);
        Task<Models.User> SetUserAsync(Models.User user);
        Task<Models.User> UpdateUserAsync(Models.User user);
        Task<List<Models.User>> GetUsersAsync();
    }
}
