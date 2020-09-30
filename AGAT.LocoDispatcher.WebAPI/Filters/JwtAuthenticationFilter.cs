using AGAT.LocoDispatcher.WebAPI.Utils.Auth;
using AGAT.LocoDispatcher.WebAPI.Utils.Auth.ResponseResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace AGAT.LocoDispatcher.WebAPI.Filters
{
    public class JwtAuthenticationFilter : AuthorizeAttribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue _auth = request.Headers.Authorization;
            if (_auth is null)
            {
                context.ErrorResult = new AuthFailureResult("Not authorized", request);
                return;
            }
            if (_auth.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthFailureResult("Invalid auth", request);
                return;
            }
            if (string.IsNullOrEmpty(_auth.Parameter))
            {
                context.ErrorResult = new AuthFailureResult("Invalid token", request);
                return;
            }
            context.Principal = TokenManager.GetPrincipal(_auth.Parameter);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            HttpResponseMessage result = await context.Result.ExecuteAsync(cancellationToken);
            //if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //{
            //    result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic","realm=localhost"));
            //}
            context.Result = new ResponseMessageResult(result);
        }
    }
}