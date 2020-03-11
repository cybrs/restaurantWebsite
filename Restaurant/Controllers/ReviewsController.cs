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
    public class ReviewsController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
           // this._repositoryWrapper = repositoryWrapper;
        }


        //public ReviewsController(IRepositoryWrapper repositoryWrapper)
        //{
        //    _repositoryWrapper = repositoryWrapper;
        //}

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Review> GetReview()
        {
            return _context.Review;
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview([FromRoute] int id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.IdReview)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> PostReview([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.IdReview }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public IActionResult Review([FromRoute] int id)
        {
            var review = _repositoryWrapper.Review.FindByCondition(x => x.IdReview.Equals(id));
            if (review == null)
            {
                return NotFound();
            }
            _repositoryWrapper.Review.Delete(review.First());

            return Ok(review.First());
        }
        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.IdReview == id);
        }
    }
}