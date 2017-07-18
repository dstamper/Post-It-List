using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostItList.Models;
using PostItList.API.Context;
using Newtonsoft.Json;

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

        // GET api/values/title
        [HttpGet("{id}")]
        public ToDoItem Get(string id)
        {
            var item = _context.Items.Find(id);

            if(item != null)
            {
                return item;
            }

            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ToDoItem item)
        {
            //TODO
            //This is currently checking to see if the item is in the DB
            //and throwing the request out if so to avoid duplicate keys
            //POST is not idempotent, so this will need to be removed once IDs are assigned
            if (_context.Items.Find(item.Title) == null)
            {
                _context.Items.Add(item);
                _context.SaveChanges();

            }
            
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]ToDoItem item)
        {
            var dbItem = _context.Items.Find(item.Title);
            if(dbItem != null)
            {
                dbItem.Completed = item.Completed;
                dbItem.DueDate = item.DueDate;

                //TODO
                //swap these once ID is the key
                dbItem.Id = item.Id;
                //dbItem.Title = item.Title;
                _context.SaveChanges();
            }
            else
            {
                //ToDoItem isn't in the database
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            

        }
    }
}
