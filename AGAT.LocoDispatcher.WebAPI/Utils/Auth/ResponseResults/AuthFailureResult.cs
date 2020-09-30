using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Utils.Auth.ResponseResults
{
    public class AuthFailureResult : IHttpActionResult
    {
        public AuthFailureResult(string message, HttpRequestMessage request)
        {
            textMessage = message;
            RequestMessage = request;
        }
        public string textMessage;
        public HttpRequestMessage RequestMessage { get; set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            message.ReasonPhrase = textMessage;
            message.RequestMessage = RequestMessage;
            return message;
        }
    }
}