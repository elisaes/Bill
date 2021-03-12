using BillManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillManager.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Index()
        {
            //List<BillModel> bills = db.Bills.ToList();
            return View();
        }

        public ActionResult Create([Bind(Include = "BillId,BillName,BillCompany,BillPrice,BillDueDate,BillStatus")] BillModel billModel)
        {
            //List<BillModel> bills = db.Bills.ToList();
            return View();
        }










        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}