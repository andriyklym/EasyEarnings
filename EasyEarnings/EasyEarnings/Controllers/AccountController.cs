using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EasyEarnings.Models;
using EasyEarnings.Contracts;
using EasyEarnings.DataAccess;
using System.Security.Cryptography;
using EasyEarnings.Helpers;
using System.Net.Mail;
using Microsoft.Owin.Host.SystemWeb;

namespace EasyEarnings.Controllers
{
    [Authorize]
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController() { }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set
            {
                _userManager = value;
            }
        }
        


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string password)
        {
            return View();
        }
    }
}