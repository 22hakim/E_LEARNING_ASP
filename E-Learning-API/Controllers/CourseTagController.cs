using Microsoft.AspNetCore.Mvc;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace E_Learning_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseTagController : Controller
{
    public readonly ICourseTagRepository _ctr;

    public CourseTagController(ICourseTagRepository courseTagRepository)
    {
        _ctr = courseTagRepository;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get()
    {

        var courseTags = from ct in await _ctr.GetAll()
                         select new Models.Dtos.AddCourseTagRequestDto()
                         {
                             CourseID = ct.CourseId,
                             TagId = ct.TagId
                         };

        return (!courseTags.Any()) ? NoContent() : Ok(courseTags);
    }

    [HttpGet]
    [NonAction]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public OkObjectResult Created([FromBody] CourseTag courseTag)
    {
        return Ok(courseTag);
    }

    [HttpPost(Name ="created")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Models.Dtos.AddCourseTagRequestDto courseTagDto)
    {
        if(ModelState.IsValid)
        {
            var createdCourse = new CourseTag()
            {
                CourseId = courseTagDto.CourseID,
                TagId = courseTagDto.TagId
            };
            await _ctr.Add(createdCourse);
            return CreatedAtAction(nameof(Get),createdCourse);
        }

        return BadRequest(new { Error = "La liaison entre tag et cours n'a pas eu lieu"});
    }

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Models.Dtos.AddCourseTagRequestDto courseTag)
    {
        var deletedCourse = new CourseTag
        {
            CourseId = courseTag.CourseID,
            TagId = courseTag.TagId
        };
        var ct = await _ctr.Delete(deletedCourse);
        return NoContent();
    }
}


