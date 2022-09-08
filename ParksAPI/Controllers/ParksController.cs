using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksAPI.Models;

namespace ParksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly ParksAPIContext _db;

        public ParksController(ParksAPIContext db)
    {
        _db = db;
    }

    // GET api/animals -- Our GET route needs to return an ActionResult of type <IEnumerable<Animal>>. In our web applications, we didn't need to specify a type because we were always returning a view.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get()
    {
        return await _db.Parks.ToListAsync();
    }

    // POST api/animals -- Our POST route utilizes the function CreatedAtAction. This is so that it can end up returning the Animal object to the user, as well as update the status code to 201, for "Created", rather than the default 200 OK.
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = park.ParkId }, park);
    }
    // GET: api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }
    [HttpDelete("{id}")]//Ultimately, the main difference between update and delete methods in a web application versus an API is the annotation. Remember that forms in HTML5 don't allow for PUT, PATCH or DELETE verbs.
    public async Task<IActionResult> Delete(int id)
    {
        var park = await _db.Parks.FindAsync(id);
        if (park == null)
        {
        return NotFound();
        }

        _db.Parks.Remove(park);
        await _db.SaveChangesAsync();

        return NoContent();
        }
    }
}