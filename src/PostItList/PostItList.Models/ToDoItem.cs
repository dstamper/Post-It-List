/* Copyright(c) 2017 Jonathan Jensen, David Stamper
    This work is available under the "MIT license".
    Please see the file LICENSE in the PostItList Github
    for license terms.*/
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PostItList.Models
{
    public class ToDoItem
    {
        public string Title { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }


    }
}
