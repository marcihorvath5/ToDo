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
            //a ViewBag-be tett adatokat a nézeten ki tudjuk olvasni
            //Figyelem az erősen típusosságot elveszítjük
            //ViewBag.Lista = list;

            return View(MyDb.Lista);
        }
        
        [HttpGet] // ezzel csak a get kéréssel fogja a routing ide írányítani
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // innentől csak a poszt kéréseket fogja ez a create kiszolgálni
        public ActionResult Create(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                MyDb.Lista.Add(new TodoItem() { Name = Name, Done = true });
                return RedirectToAction("Index");
            }

            //Mivel az adat nem valid itt kéne egy hibaüzenet
            return View();
        }
    }
}