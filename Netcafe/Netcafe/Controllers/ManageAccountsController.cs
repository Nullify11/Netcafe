using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netcafe.Models;

namespace Netcafe.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageAccountsController : Controller
    {
        // GET: ManageAccounts
        public ActionResult Index()
        {
            return View(GetUserAccounts());
        }

        private List<Account> GetUserAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var dbAccounts = db.Users.ToList();
                foreach (var row in dbAccounts)
                {
                    accounts.Add(new Account() { Id = row.Id, Name = row.Name, UserName = row.UserName, Email = row.Email });
                }
            }
            return accounts;
        }

        public void UpdateValue(object newValue, string propertyName)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
            }
        }

    }
}