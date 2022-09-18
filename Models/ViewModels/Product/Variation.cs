using Newtonsoft.Json;

namespace Hiper.Commerce.Api.Models.ViewModels.Product
{
    public class Variation
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "nomeVariacaoA")]
        public string NameVariationA { get; set; }

        [JsonProperty(PropertyName = "nomeVariacaoB")]
        public string NameVariationB { get; set; }

        [JsonProperty(PropertyName = "tipoVariacaoA")]
        public string TypeVariationA { get; set; }

        [JsonProperty(PropertyName = "tipoVariacaoB")]
        public string TypeVariationB { get; set; }
    }
}
