using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListApplication.Models
{
    public class ToDoListItems
    {
        public int Id { get; set; }
        public string ToDo { get; set; }
        public bool? IsComplete { get; set; }
    }
}