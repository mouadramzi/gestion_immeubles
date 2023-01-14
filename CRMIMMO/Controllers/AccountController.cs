using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CRMIMMO.Models;
namespace CRMIMMO.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private CRMContext22 db = new CRMContext22();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Log model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "Immobiliers");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }

            }

            return View(model);
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Account");
        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MembershipUser NewUser = Membership.CreateUser(model.UserName, model.Password);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("login", "Account");


                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Registration Error", "Registration error: " + e.StatusCode.ToString());

                }

            }
            return View(model);

        }
    }
}