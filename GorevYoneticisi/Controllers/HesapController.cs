using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GorevYoneticisi.Models;
using System.Linq;

namespace GorevYoneticisi.Controllers
{
    public class HesapController : Controller
    {
        private GorevContext db = new GorevContext();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            System.Diagnostics.Debug.WriteLine("Email: " + email);
            System.Diagnostics.Debug.WriteLine("Password: " + password);

            var user = db.User.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
            System.Diagnostics.Debug.WriteLine("User Found: " + (user != null));

            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["UserRole"] = user.UserRank;
                return RedirectToAction("Index", "Gorev");
            }

            ModelState.AddModelError("", "Invalid login attempt. Please check your email and password.");
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Hesap");
        }

    }
}