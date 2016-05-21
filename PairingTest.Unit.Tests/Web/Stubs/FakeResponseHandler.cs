using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web.Stubs
{
    public class FakeResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> _FakeResponses = new Dictionary<Uri, HttpResponseMessage>();

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            _FakeResponses.Add(uri, responseMessage);
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                if (_FakeResponses.ContainsKey(request.RequestUri))
                {
                    return _FakeResponses[request.RequestUri];
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request };
                }
            });
        }
    }
}
