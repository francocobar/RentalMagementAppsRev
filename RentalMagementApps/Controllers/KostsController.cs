using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagementApps.Data;
using RentalManagementApps.Models;
using RentalManagementApps.ExtensionMethods;

namespace RentalManagementApps.Controllers
{
    [Produces("application/json")]
    [Route("api/Kosts")]
    public class KostsController : Controller
    {
        private readonly RentalContext _context;
        protected User _user;

        public KostsController(RentalContext context)
        {
            _context = context;
        }

        // GET: api/Kosts
        [HttpGet]
        public IEnumerable<Kost> GetKost()
        {
            _user = HttpContext.Session.Get<User>("userlogin");
            return _context.Kost.Where(x=>x.UserID == _user.ID);
        }

        // GET: api/Kosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _user = HttpContext.Session.Get<User>("userlogin");
            if(_user != null)
            {
                var kost = await _context.Kost.SingleOrDefaultAsync(m => m.ID == id && m.UserID == _user.ID);

                if (kost != null)
                {
                    return Ok(kost); 
                }
            }
            return NotFound();
        }

        // PUT: api/Kosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKost([FromRoute] int id, [FromBody] Kost kost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kost.ID)
            {
                return BadRequest();
            }

            _context.Entry(kost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Kosts
        [HttpPost]
        public async Task<IActionResult> PostKost([FromBody] Kost kost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _user = HttpContext.Session.Get<User>("userlogin");
            kost.UserID = _user.ID;
            _context.Kost.Add(kost);
            await _context.SaveChangesAsync();
            var return_ = new ResponseData();
            return_.status = true;
            return_.message = kost.KostName + " telah berhasil ditambahkan";
            return_.next_page = "/Sewakost";
            return Ok(return_);
        }

        // DELETE: api/Kosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kost = await _context.Kost.SingleOrDefaultAsync(m => m.ID == id);
            if (kost == null)
            {
                return NotFound();
            }

            _context.Kost.Remove(kost);
            await _context.SaveChangesAsync();

            var return_ = new ResponseData();
            return_.status = true;
            return_.need_reload = true;
            return Ok(return_);
        }

        private bool KostExists(int id)
        {
            return _context.Kost.Any(e => e.ID == id);
        }
    }
}