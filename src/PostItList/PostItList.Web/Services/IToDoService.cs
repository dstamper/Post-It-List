/* Copyright(c) 2017 Jonathan Jensen, David Stamper
    This work is available under the "MIT license".
    Please see the file LICENSE in the PostItList Github
    for license terms.*/
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
        Task<bool> Delete(Guid item);
        
    }
}
