using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Netcafe.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Security;

namespace Netcafe.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationUsersController()
        {

        }

        public ApplicationUsersController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: ApplicationUsers
        public ActionResult Index(string sortOrder)
        {
            ViewBag.IdSortParameter = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParameter = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.EmailSortParameter = sortOrder == "email" ? "email_desc" : "email";
            ViewBag.UserNameSortParameter = sortOrder == "userName" ? "userName_desc" : "userName";

            IQueryable<ApplicationUser> users = from u in db.Users select u;

            ViewBag.Roles = GetRoles(users);

            return View(SortUsers(users, sortOrder).ToList());
        }

        private Dictionary<string, string> GetRoles(IQueryable<ApplicationUser> users)
        {
            Dictionary<string, string> IdRolePairs = new Dictionary<string, string>();

            foreach (var user in users)
            {
                IdRolePairs.Add(user.Id, user.Roles.FirstOrDefault().RoleId.ToString());
            }

            return IdRolePairs;
        }

        private IQueryable<ApplicationUser> SortUsers(IQueryable<ApplicationUser> users, string sortOrder)
        {
            switch (sortOrder)
            {
                case "id_desc":
                    users = users.OrderByDescending(u => u.Id);
                    break;
                case "name":
                    users = users.OrderBy(u => u.Name);
                    break;
                case "name_desc":
                    users = users.OrderByDescending(u => u.Name);
                    break;
                case "email":
                    users = users.OrderBy(u => u.Email);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(u => u.Email);
                    break;
                case "userName":
                    users = users.OrderBy(u => u.UserName);
                    break;
                case "userName_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                default:
                    users = users.OrderBy(u => u.Id);
                    break;
            }
            return users;
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Name = model.Name };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    string role = "Customer";

                    if (model.IsAdministrator == true)
                        role = "Administrator";

                    result = await UserManager.AddToRoleAsync(user.Id, role);
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "ApplicationUsers");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Email,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
