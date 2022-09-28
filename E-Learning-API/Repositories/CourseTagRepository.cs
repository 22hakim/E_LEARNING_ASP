using E_Learning_API.Data;
using E_Learning_API.Models;
using E_Learning_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Repositories;

public class CourseTagRepository : ICourseTagRepository
{
    private readonly ElearningDataContext _db;

    public CourseTagRepository(ElearningDataContext elearningDataContext)
    {
        _db = elearningDataContext;
    }

    public Task<bool> Add(CourseTag CourseTag)
    {
        _db.CourseTags.Add(CourseTag);
        return Save();
    }

    public Task<bool> Delete(CourseTag CourseTag)
    {
        _db.CourseTags.Remove(CourseTag);
        return Save();
    }

    public async Task<IEnumerable<CourseTag>> GetAlll()
    {
        return await _db.CourseTags.ToListAsync();
    }

    public async Task<IQueryable<CourseTag>> GetAll()
    {
        var courseTag = await _db.CourseTags.ToListAsync();
        return courseTag.AsQueryable();
    }

    public async Task<bool> Save()
    {
        bool saved = await _db.SaveChangesAsync() > 0;
        return saved;
    }

}

