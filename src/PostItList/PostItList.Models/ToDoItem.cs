using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PostItList.Models
{
    public class ToDoItem
    {
        [Key]
        public string Title { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }


    }
}
