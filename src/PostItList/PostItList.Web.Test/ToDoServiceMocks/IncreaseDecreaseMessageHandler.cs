using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using PostItList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostItList.Web.Test.ToDoServiceMocks
{
    class IncreaseDecreaseMessageHandler : HttpMessageHandler
    {
        private int count = 0;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage output, CancellationToken cancellationToken)
        {
            if (output.Method == HttpMethod.Post)
            {
                count++;
                var outputContent = new StringContent(JsonConvert.SerializeObject(Guid.NewGuid()));
                var outputMessage = new HttpResponseMessage();
                outputMessage.Content = outputContent;
                return Task.FromResult(outputMessage);
            }

            if (output.Method == HttpMethod.Delete)
            {
                if (count == 0)
                {
                    return Task.FromResult(new HttpResponseMessage());
                }
                count--;

            }
            if (output.Method == HttpMethod.Put)
            {
                return Task.FromResult(new HttpResponseMessage());
            }

            if (output.Method == HttpMethod.Get)
            {
                //var outputList = Enumerable.Repeat(new ToDoItem(), count) ?? Enumerable.Empty<ToDoItem>();
                var outputList = Enumerable.Repeat(new ToDoItem(), count);
                var outputMessage = new HttpResponseMessage();
                if (count == 0)
                {
                    outputMessage.Content = new StringContent(JsonConvert.SerializeObject(new List<ToDoItem>()), Encoding.UTF8, "application/json");
                }
                else
                {
                    var content = new StringContent(JsonConvert.SerializeObject(outputList), Encoding.UTF8, "application/json");
                    outputMessage.Content = content;

                }

                return Task.FromResult(outputMessage);

            }

            return Task.FromResult(new HttpResponseMessage());
        }
    }
}
