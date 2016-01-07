using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task2_CarOwners.Models;
using Task2_CarOwners.Models.Context;
using Task2_CarOwners.Models.Repository;

namespace Task2_CarOwners.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Owner> db;

        public HomeController()
        {
            db = new SqlOwnerRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(db.GetList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = db.GetItem(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,YearOfBirth,DrivingExperience")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Create(owner);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            Owner owner = db.GetItem(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,YearOfBirth,DrivingExperience")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Update(owner);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = db.GetItem(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            db.Save();
            return RedirectToAction("Index");
        }

        // GET: Home/AddCar/5
        public ActionResult AddCar(int id)
        {
            Owner owner = db.GetItem(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            IRepository<Car> carsDb = new SqlCarRepository();
            IEnumerable<Car> availableCars = carsDb.GetList().Except(owner.Cars).OrderBy(c => c.CarBrand).ThenBy(c => c.CarModel).ThenBy(c => c.Number);
            List<SelectListItem> cars = new List<SelectListItem>();
            foreach (var car in availableCars)
            {
                cars.Add(new SelectListItem { Value = car.Id.ToString(), Text = car.ToString() });
            }

            //SelectList cars = new SelectList(availableCars);
            ViewData["cars"] = cars;
            return View(owner);
        }

        // POST: Home/AddCar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult AddCar(int Id, int a)
        {
            //if (ModelState.IsValid)
            //{
            Owner owner = db.GetItem(Id);
            IRepository<Car> carsDb = new SqlCarRepository();
            Car car = carsDb.GetItem(a);
            owner.Cars.Add(car);
            carsDb.Update(car);
            carsDb.Save();
            db.Update(owner);
            db.Save();
            return RedirectToAction("Index");
            //}
            return View(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
