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
    public class CarsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public CarsController()
        {
            unitOfWork = new SqlUnitOfWork();
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(unitOfWork.Cars.GetList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            Car car = unitOfWork.Cars.GetItem(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarBrand,CarModel,CarType,Price,YearOfManufacture,Number")] Car car)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Cars.Create(car);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = unitOfWork.Cars.GetItem(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarBrand,CarModel,CarType,Price,YearOfManufacture,Number")] Car car)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Cars.Update(car);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            Car car = unitOfWork.Cars.GetItem(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Cars.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
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
