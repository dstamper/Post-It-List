using PostItList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostItList.Web.Services
{
    public interface IToDoService
    {
        bool Add(ToDoItem item);
        Task<IEnumerable<ToDoItem>> GetAll();
    }
}
