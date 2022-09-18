using Hiper.Commerce.Api.Models;
using Hiper.Commerce.Api.Repositories.Token;
using Hiper.Commerce.Api.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Services.Token
{
    public class TokenServices : ITokenServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenRepository _tokenRepository;

        public TokenServices(IHttpClientFactory httpClientFactory, ITokenRepository tokenRepository)
        {
            _httpClientFactory = httpClientFactory;
            _tokenRepository = tokenRepository;
        }

        public async Task<TokenModel> GetTokenAsync(string securityKey, int userId)
        {
            var tokenModel = new TokenModel();
            var accessControlHistory = new AccessControlHistory()
            {
                SecurityKey = securityKey,
                UserId = userId > 0 ? userId : null,
            };

            ValidateSecurityKey(accessControlHistory);
            if (accessControlHistory.HasErrors())
                return HandleError(accessControlHistory);

            var request = new HttpRequestMessage(HttpMethod.Get, $"auth/gerar-token/{securityKey}");
            var client = _httpClientFactory.CreateClient(nameof(TokenServices));
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var history = await _tokenRepository.SetHistory(accessControlHistory);
                if (history.HasErrors())
                    return HandleError(history);

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(responseString);
            }

            var errorMsg = new List<string>
            {
                "Houve um erro ao buscar o token. Tente novamente mais tarde.",
            };

            tokenModel.AddError(errorMsg);
            
            return tokenModel;          
        }

        static void ValidateSecurityKey(AccessControlHistory accessControlHistory)
        {
            if (accessControlHistory.SecurityKey.Length != 64)            
                accessControlHistory.AddError("A chave de segurança deve conter 64 caracteres.");            
        }

        static TokenModel HandleError(AccessControlHistory accessControlHistory)
        {
            var tokenModel = new TokenModel();

            var errorMsgByAccessControlHistory = new List<string>
                    {
                        accessControlHistory.Errors.FirstOrDefault(),
                    };
            tokenModel.AddError(errorMsgByAccessControlHistory);

            return tokenModel;
        }
    }
}
