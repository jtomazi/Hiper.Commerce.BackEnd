using Hiper.Commerce.Api.Models.ViewModels;
using Hiper.Commerce.Api.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Hiper.Commerce.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ReturnAction(BaseViewModel viewModel)
        {
            if (viewModel is null)
                return NotFound();

            if (viewModel.HasErrors())            
                return BadRequest(HandleError(viewModel));
            

            return Ok(viewModel);
        }

        static ErrorModel HandleError(BaseViewModel viewModel)
        {
            var errorModel = new ErrorModel();

            var errorMsgList = new List<string>();

            foreach (var error in viewModel.Errors)
            {
                errorMsgList.Add(error);
            }

            errorModel.AddError(errorMsgList);
            return errorModel;
        }
    }
}
