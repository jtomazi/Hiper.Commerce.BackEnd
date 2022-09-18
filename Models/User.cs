using Hiper.Commerce.Api.ViewModels.Base;
using System;

namespace Hiper.Commerce.Api.Models
{
    public class User : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Excluded { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
