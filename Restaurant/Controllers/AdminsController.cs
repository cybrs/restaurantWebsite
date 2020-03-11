using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Contracts;
using Restaurant.Data;

using Restaurant.Models;
using Restaurant.Repositories;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : Controller
    {

        private IRepositoryWrapper _repositoryWrapper;
        private readonly ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //public AdminsController(IRepositoryWrapper repositoryWrapper)
        //{
        //    _repositoryWrapper = repositoryWrapper;
        //}

        // GET: api/Admins
        [HttpGet]
        public IEnumerable<Admin> GetAdmin()
        {
            return _context.Admin;
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _context.Admin.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin([FromRoute] int id, [FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [HttpPost]
        public async Task<IActionResult> PostAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.AdminId }, admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin2([FromRoute] int id)
        {
            var admin = _repositoryWrapper.Admin.FindByCondition(x=>x.AdminId.Equals(id));
            if (admin == null)
            {
                return NotFound();
            }
            _repositoryWrapper.Admin.Delete(admin.First());
    
            return Ok(admin.First());
        }


        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.AdminId == id);
        }
    }
}