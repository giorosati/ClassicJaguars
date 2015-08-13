using ClassicJaguars.Data;
using ClassicJaguars.Data.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ClassicJaguars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString)
        {
            List<Car> Cars;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    Cars = db.Cars.ToList();
                }
                else
                {
                    Cars = db.Cars.Where(x => x.ModelName.Contains(searchString)).ToList();
                }
            }
            return View(Cars);
        }

        public ActionResult Index2()
        {
            ViewBag.Message = "Please login or register (links at upper right).";

            return View();
        }

        public ActionResult CarDetails(int id)
        {
            Car model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Cars.FirstOrDefault(x => x.ModelId == id);
            }
            return View("CarDetails", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateModel()
        {
            return View("EditModel", new Car());
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateModel(Car model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model.DateCreated = DateTime.Now;
                    model.DateDeleted = null;
                    db.Cars.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteModel(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Car model = db.Cars.FirstOrDefault(x => x.ModelId == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditModel(int id)
        {
            Car model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Cars.FirstOrDefault(x => x.ModelId == id);
            }
            return View("EditModel", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditModel(Car model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    Car tempModel = db.Cars.FirstOrDefault(x => x.ModelId == model.ModelId);
                    tempModel.ModelName = model.ModelName;
                    tempModel.FirstYear = model.FirstYear;
                    tempModel.LastYear = model.LastYear;
                    tempModel.UnitsProduced = model.UnitsProduced;
                    tempModel.Description = model.Description;
                    tempModel.Synopsis = model.Synopsis;
                    tempModel.ImgUrl = model.ImgUrl;
                    db.SaveChanges();
                }
                return RedirectToAction("CarDetails", new { id = model.ModelId });
            }
            return View("EditModel", model);
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult ModelTrans(int id)
        {
            List<Transaction> Transactions;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Transactions = db.Transactions.Include("Car").Where(x => x.ModelId == id).ToList();
            }
            return View(Transactions);
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult TransactionDetails(int id)
        {
            Transaction model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Transactions.Include("Car").FirstOrDefault(x => x.TransactionId == id);
            }
            return View("TransactionDetails", model);
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult TransactionAdd(int id)
        {
            Transaction model = new Transaction();
            model.ModelId = id;
            return View("TransactionEdit", model);
        }

        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public ActionResult TransactionAdd(Transaction model)
        {
            //var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //var userId = UserManager.FindById(User.Identity.GetUserId());
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                model.DateDeleted = null;
                db.Transactions.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult TransactionEdit(int id)
        {
            Transaction model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Transactions.FirstOrDefault(x => x.TransactionId == id);
            }
            return View("TransactionEdit", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TransactionEdit(Transaction model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Transaction tempModel = db.Transactions.FirstOrDefault(x => x.TransactionId == model.TransactionId);
                tempModel.ModelId = model.ModelId;
                tempModel.DateSold = model.DateSold;
                tempModel.TransType = model.TransType;
                tempModel.SalePrice = model.SalePrice;
                tempModel.CarYear = model.CarYear;
                tempModel.NumsMatch = model.NumsMatch;
                tempModel.ExtColor = model.ExtColor;
                tempModel.IntColor = model.IntColor;
                tempModel.SellerName = model.SellerName;
                tempModel.BuyerName = model.BuyerName;
                tempModel.BuyerCountry = model.BuyerCountry;
                tempModel.Notes = model.Notes;
                db.SaveChanges();
            }
            return View("TransactionDetails", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult TransactionDelete(int id, int carId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Transaction model = db.Transactions.FirstOrDefault(x => x.TransactionId == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("ModelTrans", new { id = carId });
        }

        public ActionResult About()
        {
            ViewBag.Message = "This site is for people who love Classic Jaguar Automobiles and our passion is owning, restoring, and sharing our 50+ years of experience in Classic Jaguar automobiles - we are here to help you!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}