using PostItList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostItList.Web.Services
{
    public interface IToDoService
    {
        //todo migrate to ID instead of title
        Task<Guid> Add(ToDoItem item);
        Task<IEnumerable<ToDoItem>> GetAll();
        Task<bool> Edit(ToDoItem item);
        Task<bool> Delete(ToDoItem item);
        
    }
}
