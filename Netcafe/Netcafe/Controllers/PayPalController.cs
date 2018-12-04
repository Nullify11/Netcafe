using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netcafe.PayPal;
namespace Netcafe.Controllers
{
    public class PayPalController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Success()
        {
            ViewBag.result = PDTHolder.Success(Request.QueryString.Get("tx"));
            return View("Success");
        }
    }
}