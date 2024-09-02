using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class Db: DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}