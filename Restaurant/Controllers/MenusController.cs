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
using ApplicationDbContext = Restaurant.Data.ApplicationDbContext;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : Controller
    {
    
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
  
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menu.ToListAsync());
        }

        // GET: api/Menus
        [HttpGet]
        public IEnumerable<Menu> GetUser()
        {
            return _context.Menu;
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.Menu.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu([FromRoute] int id, [FromBody] Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.IDMenu)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        // POST: api/Menus
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.IDMenu }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        /*public IActionResult DeleteMenu([FromRoute] int id)
        {
            var menu = _repositoryWrapper.Menu.FindByCondition(x => x.IDMenu.Equals(id));
            if (menu == null)
            {
                return NotFound();
            }
            _repositoryWrapper.Menu.Delete(menu.First());

            return Ok(menu.First());
        }*/
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singer = await _context.Menu.FindAsync(id);
            _context.Menu.Remove(singer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.IDMenu == id);
        }
    }
}

