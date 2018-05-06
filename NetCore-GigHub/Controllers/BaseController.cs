using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
    public class BaseController : Controller
    {
        protected IEnumerable<string> _GetModelStateErrors()
        {
            var errors = new List<string>();

            ModelState.Values.ToList()
                .ForEach(v =>
                    errors.AddRange(
                        v.Errors.Select(e =>
                            e.Exception == null
                                ? e.ErrorMessage
                                : throw e.Exception)));

            return errors;
        }
    }
}
