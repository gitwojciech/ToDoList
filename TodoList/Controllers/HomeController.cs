using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        static List<Task> _tasks = new List<Task>();
        static private long _id = 0;


        // GET: ToDoList
        public ActionResult Index()
        {
            return View(_tasks);
        }

        // POST: ToDoList/Create
        [HttpPost]
        public ActionResult Index(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _id++;
                _tasks.Add(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }




        //[HttpPost]
        public ActionResult DeleteTask(int id)
        {
            Task task = _tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }

            _tasks.Remove(_tasks.Find(t => t.Id == id));
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult TaskComplete(int id, bool status)
        {
            Task task = _tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            var indefOf = _tasks.IndexOf(_tasks.Find(t => t.Id == id));
            _tasks[indefOf].Status = status;

            return RedirectToAction("Index", "Home");
        }
    }
}