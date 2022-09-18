using Hiper.Commerce.Api.Models.ViewModels;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Services.Product
{
    public interface IProductServices
    {
        Task<ProductsModel> GetProductsAsync(string token);
    }
}
