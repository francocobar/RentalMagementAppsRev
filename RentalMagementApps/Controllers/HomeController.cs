using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalManagementApps.Data;
using RentalManagementApps.ExtensionMethods;
using RentalManagementApps.Models;
using RentalManagementApps.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentalManagementApps.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private readonly RentalContext _context;
        private HelperServices _helper;
        private ResponseData return_;

        public HomeController(RentalContext context)
        {
            _context = context;
            _helper = new HelperServices();
            return_ = new ResponseData();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var userLogin = HttpContext.Session.Get<object>("userlogin");
            if(userLogin != null)
            {
                return Redirect("/dashboard");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginAttr input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _context.User.SingleOrDefault(m => m.EmailAddress == input.EmailAddress);
            return_.status = user != null && _helper.hash(input.Password) == user.NewPassword;
            if(!return_.status)
            {
                return_.message = "Username atau Password salah";
            }
            else
            {
                HttpContext.Session.Set<User>("userlogin", user);
                return_.next_page = "/Dashboard";
            }
            return Ok(return_);
        }
    }
}
