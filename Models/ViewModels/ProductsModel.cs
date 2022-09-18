using Hiper.Commerce.Api.Models.ViewModels.Product;
using Hiper.Commerce.Api.ViewModels.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hiper.Commerce.Api.Models.ViewModels
{
    public class ProductsModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "pontoDeSincronizacao")]
        public int SyncPoint { get; set; }

        [JsonProperty(PropertyName = "produtos")]
        public IList<ProductModel> Products { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public IList<object> Errors { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
