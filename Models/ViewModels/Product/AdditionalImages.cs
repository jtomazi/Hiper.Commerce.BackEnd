using Newtonsoft.Json;

namespace Hiper.Commerce.Api.Models.ViewModels.Product
{
    public class AdditionalImages
    {
        [JsonProperty(PropertyName = "imagem")]
        public string Image { get; set; }
    }
}
