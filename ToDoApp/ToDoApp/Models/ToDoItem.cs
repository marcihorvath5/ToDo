using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class TodoItem
    {
        public string Name { get; set; }
        public bool Done { get; internal set; }
        public int Id {get; internal set; }
    }
}