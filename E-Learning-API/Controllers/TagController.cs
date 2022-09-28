using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get()
    {
        var tags = await _tr.GetAll();
        return (!tags.Any()) ? NoContent() : Ok(tags);
    }

    // GET api/values/5
    [HttpGet("{id}"), ActionName("GetValue")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tag))]
    public async Task<IActionResult> Get(int id)
    {
        var t = await _tr.GetByIdAsyncUntracked(id);
        return t is null ? NotFound() : Ok(t); 
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Post(Tag tag)
    {
        await _tr.Add(tag);
        return CreatedAtAction(nameof(Get), new { id = tag.Id }, tag);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent,Type = typeof(Tag))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Put(int id, Tag tag)
    {
        if (id != tag.Id) return BadRequest();

        await _tr.Update(tag);
        return NoContent();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(int id)
    {
        Tag? t = await _tr.GetByIdAsyncUntracked(id);
        if (t is null) return NotFound();

        await _tr.Delete(t);
        return NoContent();
    }
}

