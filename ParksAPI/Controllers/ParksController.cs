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
    [Route("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly ParksAPIContext _db;

        public ParksController(ParksAPIContext db)
    {
        _db = db;
    }
    
    /// <summary>
    /// Park List
    /// </summary>
    /// <remarks>
    ///
    /// Sample request:
    /// GET /api/parks
    ///     
    /// </remarks>
    /// 
    /// <returns>Park List</returns>
    /// <response code="200">Returns Park List</response>
    /// <response code="400">If the park is null</response> 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get()
    {
        return await _db.Parks.ToListAsync();
    }

    /// <summary>
    /// Creates Park.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Park
    ///     {
    ///        "id": 1,
    ///        "name": "Yellowstone",
    ///        "state": "Montana"
    ///     }
    ///
    /// </remarks>
    /// 
    /// <returns>A newly created park</returns>
    /// <response code="201">Returns the newly created park</response>
    /// <response code="400">If the park is null</response> 
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Park>> Post(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }
    
    /// <summary>
    /// Update Park 
    /// </summary>
    /// <remarks>
    ///
    /// Sample request:
    /// DELETE /api/parks/1 
    ///     
    /// </remarks>
    /// 
    /// <returns>Delete park in API</returns>
    /// <response code="201">Park Deleted Successfully</response>
    /// <response code="400">If the park is null</response> 
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
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
    
    /// <summary>
    /// Delete Park 
    /// </summary>
    /// <remarks>
    ///
    /// 
    ///     
    /// </remarks>
    /// 
    /// <returns>Park List</returns>
    /// <response code="201">Park Updated successfully</response>
    /// <response code="400">If the park is null</response>    
    [HttpDelete("{id}")]
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

    private bool ParkExists(int id)
    {
        return _db.Parks.Any(e => e.ParkId == id);
        }
    }
}
