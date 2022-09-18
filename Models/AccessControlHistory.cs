using Hiper.Commerce.Api.Models.Base;
using System;

namespace Hiper.Commerce.Api.Models
{
    public class AccessControlHistory : BaseModel
    {
        public int Id { get; set; }

        public string SecurityKey { get; set; }

        public DateTime AccessDate { get; set; } = DateTime.Now;

        public int? UserId { get; set; }
    }
}
