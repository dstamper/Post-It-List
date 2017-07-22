using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostItList.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PostItList.Web.Config;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace PostItList.Web.Services
{
    public class ToDoService : IToDoService
    {
        private readonly UserSettings _userSettings;
        private readonly HttpMessageHandler _handler;
        public ToDoService(IOptions<UserSettings> settings, HttpMessageHandler handler)
        {
            _userSettings = settings.Value;
            _handler = handler;


        }
        public async Task<Guid> Add(ToDoItem item)
        {
            if (item != null)
            {
                using (var client = new HttpClient(_handler))
                {
                    client.BaseAddress = new Uri(_userSettings.APIURL);

                    var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                    //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync("values", content);
                    var json = await response.Content.ReadAsStringAsync();
                    var id = JsonConvert.DeserializeObject<Guid>(json);
                    return id;
                }
            }
            else
            {
                return default(Guid);

            }
        }

        public async Task<bool> Delete(ToDoItem item)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(_userSettings.APIURL);
                var response = await client.DeleteAsync(item.Id.ToString());

                return response.IsSuccessStatusCode;
            }

        }

        //consider refactoring to return actual status code
        //for cleaner controller
        public async Task<bool> Edit(ToDoItem item)
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(_userSettings.APIURL);
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                //TODO take out redundant ID line
                var response = await client.PutAsync("values/"+ item.Id.ToString(), content);

                return response.IsSuccessStatusCode;
                
            }
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            using (var client = new HttpClient(_handler))
            {
                client.BaseAddress = new Uri(_userSettings.APIURL);
                var response = await client.GetAsync("values");
                if (response.Content != null)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<IEnumerable<ToDoItem>>(json);
                    if (items == null)
                    {
                        return Enumerable.Empty<ToDoItem>();
                    }
                    return items;
                }
                return Enumerable.Empty<ToDoItem>();
            }
        }
    }
}
