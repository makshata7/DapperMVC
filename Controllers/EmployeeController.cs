using DapperMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace DapperMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository repository;

        public EmployeeController()
        {
            repository = new EmployeeRepository();
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                repository.Create(employee);
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employees employee)
        {
            if (ModelState.IsValid)
            {
                repository.Update(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
