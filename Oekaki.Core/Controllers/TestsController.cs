using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oekaki.Data;
using Oekaki.Data.Models;

namespace Oekaki.Core.Controllers;

[Route("[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Tests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Test>>> GetTests()
    {
        return await _context.Tests.ToListAsync();
    }

    // GET: /Tests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Test>> GetTest(int id)
    {
        var test = await _context.Tests.FindAsync(id);

        if (test == null)
        {
            return NotFound();
        }

        return test;
    }

    // PUT: /Tests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTest(int id, Test test)
    {
        if (id != test.Id)
        {
            return BadRequest();
        }

        _context.Entry(test).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestExists(id))
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

    // POST: /Tests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Test>> PostTest(Test test)
    {
        _context.Tests.Add(test);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTest", new { id = test.Id }, test);
    }

    // DELETE: /Tests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTest(int id)
    {
        var test = await _context.Tests.FindAsync(id);
        if (test == null)
        {
            return NotFound();
        }

        _context.Tests.Remove(test);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TestExists(int id)
    {
        return _context.Tests.Any(e => e.Id == id);
    }
}
