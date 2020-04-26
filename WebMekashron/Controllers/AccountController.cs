using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMekashron.ServiceReference;
using WebMekashron.Security;
using WebMekashron.Services;
using WebMekashron.ViewModels;

namespace WebMekashron.Controllers
{
    public class AccountController : Controller
    {
        

        public ActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "User name or password is wrong");

                return View(model);
            }

            var error = "";
            if (!MembershipHelper.LogIn(model, Request.UserHostAddress, ref error))
            {
                ModelState.AddModelError("", error);

                return View(model);
            }

            return RedirectToAction("Index", "User");
        }

        public ActionResult Register()
        {
            var model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Customer details not validate");

                return View(model);
            }

            var error = "";
            if (!MembershipHelper.Register(model, Request.UserHostAddress, ref error))
            {
                ModelState.AddModelError("", error);

                return View(model);
            }

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            MembershipHelper.LogOff();

            return RedirectToAction("Index", "Home");
        }

    }
}