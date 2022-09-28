using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using E_Learning_API.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Repositories;

public class CoursesRepository : ICourseRepository
{
    private readonly ElearningDataContext _db;

    public CoursesRepository(ElearningDataContext elearningDataContext)
    {
        _db = elearningDataContext;
    }

    public Task<bool> Add(Course c)
    {
        _db.Add(c);
        return Save();
    }

    public Task<bool> Update(Course c)
    {
        _db.Update(c);
        return Save();
    }

    public Task<bool> Delete(Course c)
    {
        _db.Remove(c);
        return Save();
    }

    public async Task<IEnumerable<Course>> GetAll()
    {
        return await _db.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _db.Courses.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Course?> GetByIdAsyncUntracked(int id)
    {
        return await _db.Courses.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<bool> Save()
    {
        bool saved = await _db.SaveChangesAsync() > 0;
        return saved;
    }
}

