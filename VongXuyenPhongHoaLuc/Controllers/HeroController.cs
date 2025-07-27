using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VongXuyenPhongHoaLuc.Models;

namespace VongXuyenPhongHoaLuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly GameDbContext _context;
        public HeroController(GameDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Heroes.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            return hero == null ? NotFound() : Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hero updated)
        {
            if (id != updated.Id) return BadRequest();
            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null) return NotFound();
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
