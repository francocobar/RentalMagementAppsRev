using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalManagementApps.Data;
using RentalManagementApps.Models;
using RentalManagementApps.ExtensionMethods;

namespace RentalManagementApps.Controllers
{
    public class SewaKostController : Controller
    {
        private readonly RentalContext _context;
        protected User _user;

        public SewaKostController(RentalContext context)
        {
            _context = context;
        }
        // GET: SewaKost
        public ActionResult Index()
        {
            return View();
        }

        // GET: SewaKost/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: SewaKost/Createroom/5
        public ActionResult Createroom(int id)
        {
            _user = HttpContext.Session.Get<User>("userlogin");
            if(_user!=null)
            {
                var kost = _context.Kost.SingleOrDefault(m => m.ID == id && m.UserID == _user.ID);
                if(kost!= null)
                {
                    ViewData["KostId"] = kost.ID;
                    ViewData["KostName"] = kost.KostName;
                    return View();
                }
            }
            return Redirect("/");
        }

        // GET: SewaKost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SewaKost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}