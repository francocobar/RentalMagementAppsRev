using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalManagementApps.ExtensionMethods;
using RentalManagementApps.Models;

namespace RentalManagementApps.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var userLogin = HttpContext.Session.Get<User>("userlogin");
            if (userLogin == null)
            {
                return Redirect("/");
            }
            return View();
        }        
    }
}