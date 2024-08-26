using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class TodoController: Controller
    {
        public ActionResult Index()
        {
            // bevásárló lista
            var lista = new List<TodoItem>();

            lista.Add(new TodoItem() { Name = "Só", Done = true });
            lista.Add(new TodoItem() { Name = "Cukor", Done = true });
            lista.Add(new TodoItem() { Name = "Spagetti", Done = true });
            lista.Add(new TodoItem() { Name = "Marhahús", Done = false });
            lista.Add(new TodoItem() { Name = "Paradicsom", Done = false });
            //a ViewBag-be tett adatokat a nézeten ki tudjuk olvasni
            //Figyelem az erősen típusosságot elveszítjük
            //ViewBag.Lista = list;

            return View(lista);
        }
    }
}