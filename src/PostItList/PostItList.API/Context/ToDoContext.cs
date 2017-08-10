/* Copyright (c) 2017 Jonathan Jensen, David Stamper
 This work is available under the "MIT license".
 Please see the file COPYING in this distribution
 for license terms.*/
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
