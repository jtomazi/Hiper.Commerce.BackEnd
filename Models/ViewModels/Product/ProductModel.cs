using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hiper.Commerce.Api.Models.ViewModels.Product
{
    public class ProductModel
    {
        [JsonProperty(PropertyName = "altura")]
        public decimal Height { get; set; }

        [JsonProperty(PropertyName = "ativo")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "categoria")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "codigo")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "codigoDeBarras")]
        public string BarCode { get; set; }

        [JsonProperty(PropertyName = "comprimento")]
        public decimal Length { get; set; }

        [JsonProperty(PropertyName = "cor")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "grade")]
        public bool Grid { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "imagem")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "imagensAdicionais")]
        public IList<AdditionalImages> AdditionalImages { get; set; }

        [JsonProperty(PropertyName = "largura")]
        public decimal Width { get; set; }

        [JsonProperty(PropertyName = "marca")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "ncm")]
        public string Ncm { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "peso")]
        public decimal Weight { get; set; }

        [JsonProperty(PropertyName = "preco")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "produtoPrimarioId")]
        public string PrimaryProductId { get; set; }

        [JsonProperty(PropertyName = "quantidadeEmEstoque")]
        public decimal QuantityInStock { get; set; }

        [JsonProperty(PropertyName = "quantidadeMinimaEmEstoque")]
        public int MinimumQuantityInStock { get; set; }

        [JsonProperty(PropertyName = "tamanho")]
        public string Size { get; set; }

        [JsonProperty(PropertyName = "unidade")]
        public string Unity { get; set; }

        [JsonProperty(PropertyName = "variacao")]
        public IList<Variation> Variation { get; set; }
    }
}
