using Hiper.Commerce.Api.Models;
using Hiper.Commerce.Api.ViewModels;
using System;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Services.Token
{
    public interface ITokenServices
    {
        Task<TokenModel> GetTokenAsync(string securityKey, int userId);

        static void ValidateSecurityKey(AccessControlHistory accessControlHistory) => throw new NotImplementedException();

        static TokenModel HandleError(AccessControlHistory accessControlHistory) => throw new NotImplementedException();
    }
}
