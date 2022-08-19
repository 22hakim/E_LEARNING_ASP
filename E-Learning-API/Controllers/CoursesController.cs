using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Learning_API.Repositories;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;


namespace E_Learning_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : Controller
{
    private readonly ICoursesRepository _cr;

    public CoursesController(ICoursesRepository coursesRepository)
    {
        _cr = coursesRepository;
    }

    // GET: api/values
    [HttpGet]
    public async Task<IEnumerable<Courses>> Get()
    {
        return await _cr.GetAll();
    }

    // GET api/values/5
    [HttpGet("{id}"),ActionName("GetValue")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Courses))]
    public async Task<IActionResult> Get(int id)
    {
        Courses? courses = await _cr.GetByIdAsyncUntracked(id);
        return courses == null ? NotFound() : Ok(courses);
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Courses course)
    {
        await _cr.Add(course);
        return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Courses))]
    public IActionResult Edit(int id, Courses course)
    {
        if (id != course.Id) return BadRequest();

        _cr.Update(course);
        return NoContent();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id, Courses Course)
    {
        Courses? courses = await _cr.GetByIdAsyncUntracked(id);
        if (courses == null) return NotFound();

        await _cr.Delete(Course);
        return NoContent();
    }
}

