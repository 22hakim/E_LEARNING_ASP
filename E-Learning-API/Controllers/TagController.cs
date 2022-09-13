using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_Learning_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : Controller
{
    private readonly ITagRepository _tr;

    public TagController(ITagRepository tagRepository)
    {
        _tr = tagRepository;
    }

    // GET: api/values
    [HttpGet]
    public async Task<IEnumerable<Tag>> Get()
    {
        return await _tr.GetAll();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tag))]
    public async Task<IActionResult> Get(int id)
    {
        Tag? t = await _tr.GetByIdAsyncUntracked(id);
        return null == t ? NotFound() : Ok(t); 
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(Tag tag)
    {
        await _tr.Add(tag);
        return CreatedAtAction(nameof(Get), new { id = tag.Id }, tag);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent,Type = typeof(Tag))]
    public async Task<IActionResult> Edit(int id, Tag tag)
    {
        if (id != tag.Id) return BadRequest();

        await _tr.Update(tag);
        return NoContent();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        Tag? t = await _tr.GetByIdAsyncUntracked(id);
        if (t is null) return NotFound();

        await _tr.Delete(t);
        return NoContent();
    }
}

