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
        Db db = new Db();
       
        public ActionResult Index()
        {                       
            //a ViewBag-be tett adatokat a nézeten ki tudjuk olvasni
            //Figyelem az erősen típusosságot elveszítjük
            //ViewBag.Lista = list;

            return View(db.TodoItems.ToList());
        }
        
        [HttpGet] // ezzel csak a get kéréssel fogja a routing ide írányítani
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // innentől csak a poszt kéréseket fogja ez a create kiszolgálni
        public ActionResult Create(string name, bool isDone)
        {
            if (!string.IsNullOrEmpty(name))
            {
                // Count nem jó most mert ha törlök egyet akkor 2 ugyanolyan elemem lenne
                // var maxId = MyDb.Lista.Count;
                //var maxId = MyDb.Lista.Max(x => x.Id);

                db.TodoItems.Add(new TodoItem() {Name = name, Done = isDone });
                // Adatbázisba írás
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Mivel az adat nem valid itt kéne egy hibaüzenet
            return View();
        }

        /// <summary>
        /// Az action feladata az adott elem megjelenítése módosításra
        /// </summary>
        /// <param name="id">A módosítandó tétel egyedi azonosítója paraméter</param>
        /// <returns></returns>
        [HttpGet]  
        public ActionResult Edit(int id)
        {
            // Elő kell keresni az elemet
            // MyDb.Lista.Where(x => x.Id == id); // ezzel a lambda fügvénnyel szűröm az elemet aminek egyezik az id-vel
            
            //a single csak akkor működik ha pontosan 1 ilyen elem van
            var item = db.TodoItems.Single(x => x.Id == id);
            //Ha nem tudom garantálni akkor
            // ha van ilyen elem azzal tér vissza
            // ha nincs ilyen elem akkor 0-al tér vissza
            // var item = MyDb.Lista.SingleOrDefault(x => x.Id == id);

            // ezt az elemet kell módosítanunk

            return View(item);
        }

        [HttpPost] 
        public ActionResult Edit(int id, string name, bool done)
        {
            var item = db.TodoItems.Single(x => x.Id == id);
            item.Name = name;
            item.Done = done;

            db.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(int id) 
        {
            var item = db.TodoItems.Single(x => x.Id == id);
            return View(item);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = db.TodoItems.Single(x => x.Id == id);

            db.TodoItems.Remove(item);            
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var item = db.TodoItems.Single(x => x.Id == id);
            return View(item);
        }
    }
}