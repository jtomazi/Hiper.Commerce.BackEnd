using Hiper.Commerce.Api.Controllers.Base;
using Hiper.Commerce.Api.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Controllers.User
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : BaseController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Route("check-user-credentials")]
        public async Task<IActionResult> GetUserDataAsync([FromHeader] string email, [FromHeader] string passWord) =>
            ReturnAction(await _userServices.GetUserDataAsync(email, passWord));

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync() =>
            ReturnAction(await _userServices.GetUsersAsync());

        [HttpPost]
        public async Task<IActionResult> SetUserAsync([FromBody] Models.User user) =>
            ReturnAction(await _userServices.SetUserAsync(user));      

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserByIdAsync([FromRoute] int id) =>
            ReturnAction(await _userServices.DeleteUserByIdAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] Models.User user) =>
            ReturnAction(await _userServices.UpdateUserAsync(user));
    }
}
