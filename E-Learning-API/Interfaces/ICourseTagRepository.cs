using E_Learning_API.Data;
using E_Learning_API.Models;
using E_Learning_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Interfaces;

public interface ICourseTagRepository
{
    Task<IEnumerable<CourseTag>> GetAlll();

    Task<IQueryable<CourseTag>> GetAll();

    Task<bool> Add(CourseTag CourseTag);

    Task<bool> Delete(CourseTag CourseTag);

    Task<bool> Save();
}



