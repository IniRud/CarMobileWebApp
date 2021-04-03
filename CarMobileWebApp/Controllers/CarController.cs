
using CarMobileWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMobileWebApp.Controllers
{
    public class CarController : Controller
    {
        private ApplicationDbContext context;
        public CarController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Car
        public ActionResult Index()
        {
            List<CarModel> cars = context.carModels.ToList();
 
            return View("Index", cars);
        }



        public ActionResult Details(int id)
        {
            CarModel car = context.carModels.SingleOrDefault(c => c.Id == id);

            return View("Details", car);
        }

        public ActionResult Create()
        {
            return View("CarForm", new CarModel());
        }

        public ActionResult Edit(int id)
        {
            CarModel car = context.carModels.SingleOrDefault(c => c.Id == id);

            return View("CarForm", car);
        }

        //Important
        public ActionResult Delete(int id) 
        {
            CarModel car = context.carModels.SingleOrDefault(c => c.Id == id);
            //IMPORTANT
            context.Entry(car).State = EntityState.Deleted;

            context.SaveChanges();

            return Redirect("/Car");
        }
        [HttpPost]
        public ActionResult ProcessCreate(CarModel carModel)
        {
            CarModel car = context.carModels.SingleOrDefault(c => c.Id == carModel.Id);

            //edit
            if(car != null)
            {
                car.Model = carModel.Model;
                car.Production = carModel.Production;

                context.SaveChanges();
            }
            else
            {
                context.carModels.Add(carModel);
            }
            context.SaveChanges();

            return View("Details", carModel);
        }

        public ActionResult SearchForm()
        {
            
            return View("SearchForm");
        }

        public ActionResult Search(string search)
        {
            var cars = from c in context.carModels
                       where c.Model.Contains(search)
                       select c;

            return View("Index", cars);
        }

    }
}