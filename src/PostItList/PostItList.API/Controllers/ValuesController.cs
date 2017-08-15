/* Copyright(c) 2017 Jonathan Jensen, David Stamper
    This work is available under the "MIT license".
    Please see the file LICENSE in the PostItList Github
    for license terms.*/
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
        public ToDoItem Get(Guid id)
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
        public Guid Post([FromBody]ToDoItem item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedDate = DateTime.Now;
            _context.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]ToDoItem item)
        {
            var dbItem = _context.Items.Find(id);
            if(dbItem != null)
            {
                dbItem.Completed = item.Completed;
                dbItem.DueDate = item.DueDate;
                dbItem.Title = item.Title;
                _context.SaveChanges();
                //Processed sucessfully no response body needed
                Response.StatusCode = 204;
            }
            else
            {
                //ToDoItem isn't in the database
                //TODO response 
                Response.StatusCode = 404;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var dbItem = _context.Items.Find(id);
            if(dbItem != null)
            {
                _context.Items.Remove(dbItem);
                _context.SaveChanges();
            }
            else
            {
                //ToDoItem isn't in the database
                //TODO response 
            }
        }
    }
}
