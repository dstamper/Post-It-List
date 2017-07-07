using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostItList.Models;
using PostItList.API.Context;

namespace PostItList.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ToDoContext _context;

        public ValuesController(ToDoContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            if (_context.Items.Count() == 0)
            {
                var item1 = new ToDoItem { Title = "Item1" };
                var item2 = new ToDoItem { Title = "Item2" };
                return new[] { item1, item2 };
            }

            return _context.Items.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var item = new ToDoItem { Title = "sdfsdf"};
            return item.Title;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
