using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Hiper.Commerce.Api.ViewModels.Base
{
    public class BaseViewModel
    {
        protected BaseViewModel()
        {
            Errors ??= new List<string>();
        }

        [NotMapped]
        public ICollection<string> Errors { get; set; }

        public void AddError(IList<string> errors)
        {
            foreach (var error in errors)
            {
                if (!Errors.Contains(error))
                    Errors.Add(error);
            }            
        }

        public void AddError(string errorMsg)
        {
            var errorMsgList = new List<string>
            {
                errorMsg
            };

            AddError(errorMsgList);
        }

        public bool HasErrors() => Errors.Any();
    }
}
