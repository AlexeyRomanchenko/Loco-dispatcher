using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace AGAT.LocoDispatcher.WebAPI.Handlers
{
    public class ErrorHandler
    {
        public static IEnumerable<string> HandleErrors(ModelStateDictionary model)
        {
            foreach (var errorObject in model.Values)
            {
                foreach (var error in errorObject.Errors)
                {
                    yield return error.ErrorMessage;
                }
            }
        }
    }
}