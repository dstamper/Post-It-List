using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostItList.Web.Test
{
    class ShouldNotAllowNulltoBeAddedMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(request.Method == HttpMethod.Post)
            {
                
            }
        }
    }
}
