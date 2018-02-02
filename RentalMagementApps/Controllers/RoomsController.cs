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
    [Route("api/Rooms")]
    public class RoomsController : Controller
    {
        private readonly RentalContext _context;
        protected User _user;

        public RoomsController(RentalContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Room> GetRoom()
        {
            return _context.Room;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _user = HttpContext.Session.Get<User>("userlogin");
            if(_user != null)
            {
                var room = await _context.Room.SingleOrDefaultAsync(m => m.ID == id);
                if (room != null)
                {
                    return Ok(room);
                }
                          
            }
            return NotFound();
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom([FromRoute] int id, [FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            room.ID = id;

            _context.Entry(room).State = EntityState.Modified;
            var return_ = new ResponseData();
            try
            {
                await _context.SaveChangesAsync();
                return_.status = true;
                return_.message = "Data berhasil diperbahrui";
            }
            catch (DbUpdateConcurrencyException)
            {
                
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return_.status = false;
                    return_.need_reload = true;
                }
            }

            return Ok(return_);
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<IActionResult> PostRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var return_ = new ResponseData();
            if(room.KostID != 0)
            {
                _user = HttpContext.Session.Get<User>("userlogin");
                _context.Room.Add(room);
                await _context.SaveChangesAsync();

                return_.status = true;
                return_.message = "Kamar berhasil ditambahkan";
                return_.next_page = "/Sewakost";
            }
            else
            {
                return_.status = false;
                return_.need_reload = true;
                return_.message = "Terjadi kesalahan. Silahkan coba lagi.";
            }

            return Ok(return_);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _user = HttpContext.Session.Get<User>("userlogin");
            if (_user != null)
            {
                var room = await _context.Room.SingleOrDefaultAsync(m => m.ID == id);

                var return_ = new ResponseData();
                return_.message = room.RoomName + " berhasil dihapus!";
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
                return_.status = true;
                return_.need_reload = true;
                return Ok(return_);
            }

            return NotFound();


        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.ID == id);
        }
    }
}