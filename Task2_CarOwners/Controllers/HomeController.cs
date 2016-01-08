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
using Task2_CarOwners.Models.Repository.SqlRepository;

namespace Task2_CarOwners.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(unitOfWork.Owners.GetList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = unitOfWork.Owners.GetItem(id);
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
                unitOfWork.Owners.Create(owner);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            Owner owner = unitOfWork.Owners.GetItem(id);
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
                unitOfWork.Owners.Update(owner);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = unitOfWork.Owners.GetItem(id);
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
            unitOfWork.Owners.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // GET: Home/AddCar/5
        public ActionResult AddCar(int id)
        {
            Owner owner = unitOfWork.Owners.GetItem(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Car> availableCars = unitOfWork.Cars.GetList().Except(owner.Cars).OrderBy(c => c.CarBrand).ThenBy(c => c.CarModel).ThenBy(c => c.Number);
            List<SelectListItem> cars = new List<SelectListItem>();
            foreach (var car in availableCars)
            {
                cars.Add(new SelectListItem { Value = car.Id.ToString(), Text = car.ToString() });
            }
            ViewData["cars"] = cars;
            return View(owner);
        }

        // POST: Home/AddCar/5
        [HttpPost]
        public ActionResult AddCar(int Id, int carId)
        {
            Owner owner = unitOfWork.Owners.GetItem(Id);
            Car car = unitOfWork.Cars.GetItem(carId);
            if (ModelState.IsValid)
            {
                owner.Cars.Add(car);
                unitOfWork.Cars.Update(car);
                unitOfWork.Owners.Update(owner);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Home/DeleteCar/5
        public ActionResult DeleteCar(int id)
        {
            Owner owner = unitOfWork.Owners.GetItem(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Car> garage = owner.Cars;
            List<SelectListItem> cars = new List<SelectListItem>();
            foreach (var car in garage)
            {
                cars.Add(new SelectListItem { Value = car.Id.ToString(), Text = car.ToString() });
            }
            ViewData["cars"] = cars;
            return View(owner);
        }

        // POST: Home/DeleteCar/5
        [HttpPost]
        public ActionResult DeleteCar(int Id, int carId)
        {
            Owner owner = unitOfWork.Owners.GetItem(Id);
            Car car = unitOfWork.Cars.GetItem(carId);
            if (ModelState.IsValid)
            {
                owner.Cars.Remove(car);
                unitOfWork.Cars.Update(car);
                unitOfWork.Owners.Update(owner);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
