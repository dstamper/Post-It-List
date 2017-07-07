using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostItList.Models;

namespace PostItList.Web.Services
{
    public class ToDoService : IToDoService
    {
        public bool Add(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            var item1 = new ToDoItem { Title = "Item1" };
            var item2 = new ToDoItem { Title = "Item2" };
            var item3 = new ToDoItem { Title = "Item3" };
            return new[] { item1, item2, item3 };
        }
    }
}
