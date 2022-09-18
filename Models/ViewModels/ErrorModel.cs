using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiper.Commerce.Api.Models.ViewModels
{
    public class ErrorModel
    {
        public ErrorModel()
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
    }
}
