using Hiper.Commerce.Api.Controllers.Base;
using Hiper.Commerce.Api.Services.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Controllers.Product
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : BaseController
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromHeader] string token) =>
            ReturnAction(await _productServices.GetProductsAsync(token));
    }
}
