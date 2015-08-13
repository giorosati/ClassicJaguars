using ClassicJaguars.Data;
using ClassicJaguars.Data.Model;
using ClassicJaguars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassicJaguars.Controllers
{
    public class TransactionController : Controller
    {
        public ActionResult TransactionDetails(int id)
        {
            Transaction model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Transactions.FirstOrDefault(x => x.TransactionId == id);
            }
            return View("TransactionDetails", model);
        }

        public ActionResult TransactionEdit(int id)
        {
            Transaction model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Transactions.FirstOrDefault(x => x.TransactionId == id);
            }
            return View("TransactionEdit", model);
        }
    }
}