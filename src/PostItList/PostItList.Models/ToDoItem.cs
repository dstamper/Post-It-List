using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PostItList.Models
{
    public class ToDoItem
    {
        [Key]
        public string Title { get; set; }

    }
}
