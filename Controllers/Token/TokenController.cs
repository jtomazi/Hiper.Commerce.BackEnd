using Hiper.Commerce.Api.Controllers.Base;
using Hiper.Commerce.Api.Services.Token;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Controllers.Token
{
    [ApiController]
    [Route("v1/token")]
    public class TokenController : BaseController
    {
        private readonly ITokenServices _tokenServices;

        public TokenController(ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTokenAsync([FromHeader] string securityKey, [FromHeader] int userId) => 
            ReturnAction(await _tokenServices.GetTokenAsync(securityKey, userId));
    }
}
