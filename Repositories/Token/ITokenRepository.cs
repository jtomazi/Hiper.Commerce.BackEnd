using Hiper.Commerce.Api.Models;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Repositories.Token
{
    public interface ITokenRepository
    {
        Task<AccessControlHistory> SetHistory(AccessControlHistory accessControlHistory);
    }
}
