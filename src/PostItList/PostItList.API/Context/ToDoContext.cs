using Microsoft.EntityFrameworkCore;
using PostItList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostItList.API.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        //TODO IDs
        public DbSet<ToDoItem> Items { get; set; }


    }
}
