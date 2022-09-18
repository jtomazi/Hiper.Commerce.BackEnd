using Hiper.Commerce.Api.ViewModels.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hiper.Commerce.Api.ViewModels
{
    public class TokenModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "chaveDeSeguranca")]
        public string SecurityKey { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public IList<object> Errors { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
