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
        public ToDoService(IOptions<UserSettings> settings)
        {
            _userSettings = settings.Value;

        }
        public async Task<bool> Add(ToDoItem item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_userSettings.APIURL);

                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync("values", content);

                return response.IsSuccessStatusCode;
            }
        }

        public Task<bool> Delete(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem> Get(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_userSettings.APIURL);
                var response = await client.GetAsync("values");
                var json = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<IEnumerable<ToDoItem>>(json);
                return items;
            }
        }
    }
}
