using Hiper.Commerce.Api.Models.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductsModel> GetProductsAsync(string token)
        {
            var productsModel = new ProductsModel();

            var request = new HttpRequestMessage(HttpMethod.Get, "produtos/pontoDeSincronizacao?pontoDeSincronizacao=0");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var client = _httpClientFactory.CreateClient(nameof(ProductServices));
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductsModel>(responseString);
            }

            productsModel.AddError("Houve um erro ao buscar os produtos. Tente novamente mais tarde.");
            return productsModel;
        }
    }
}
