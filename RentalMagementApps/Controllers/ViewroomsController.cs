using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagementApps.Data;
using RentalManagementApps.Models;
using RentalManagementApps.ExtensionMethods;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentalManagementApps.Controllers
{
    public class ViewroomsController : Controller
    {
        private readonly RentalContext _context;
        protected User _user;

        public ViewroomsController(RentalContext context)
        {
            _context = context;
        }

        // GET: Viewrooms/List/5
        public async Task<IActionResult> List(int id)
        {
            _user = HttpContext.Session.Get<User>("userlogin");
            if(_user != null)
            {
                var kost = _context.Kost.Where(x => x.ID == id && _user.ID == x.UserID);
                if(kost!=null)
                {
                    return View(await _context.Room.Where(m => m.KostID == id).ToListAsync());
                }
            }

            return Redirect("/Dashboard");
        }

        public IActionResult Edit(int id)
        {
            ViewData["id"] = id;
            return View();
        }
    }
}
