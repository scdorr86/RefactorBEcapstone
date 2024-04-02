using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;


namespace RefactorBEcapstone.Controllers
{
    public class BaseController : ControllerBase
    {
        public static string GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = string.Empty;
            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors += $"{error.ErrorMessage} ";
                }
            }
            return errors;
        }
        internal string GetUserId()
        {
            return User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
