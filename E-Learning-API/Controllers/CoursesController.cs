using Microsoft.AspNetCore.Mvc;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;


namespace E_Learning_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : Controller
{
    private readonly ICourseRepository _cr;

    public CoursesController(ICourseRepository coursesRepository)
    {
        _cr = coursesRepository;
    }

    // GET: api/values
    [HttpGet]
    public async Task<IEnumerable<Course>> Get()
    {
        return await _cr.GetAll();
    }

    // GET api/values/5
    [HttpGet("{id}"),ActionName("GetValue")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Course))]
    public async Task<IActionResult> Get(int id)
    {
        Course? c = await _cr.GetByIdAsyncUntracked(id);
        return c == null ? NotFound() : Ok(c);
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Course c)
    {
        await _cr.Add(c);
        return CreatedAtAction(nameof(Get), new { id = c.Id }, c);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Course))]
    public IActionResult Edit(int id, Course c)
    {
        if (id != c.Id) return BadRequest();

        _cr.Update(c);
        return NoContent();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id, Course c)
    {
        Course? courses = await _cr.GetByIdAsyncUntracked(id);
        if (courses == null) return NotFound();

        await _cr.Delete(c);
        return NoContent();
    }
}

