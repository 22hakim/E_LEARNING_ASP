using System;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using E_Learning_API.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Repositories;

public class CoursesRepository : ICoursesRepository
{
    private readonly ElearningDataContext _db;

    public CoursesRepository(ElearningDataContext elearningDataContext)
    {
        _db = elearningDataContext;
    }

    public Task<bool> Add(Courses Course)
    {
        _db.Add(Course);
        return Save();
    }

    public Task<bool> Update(Courses Course)
    {
        _db.Update(Course);
        return Save();
    }

    public Task<bool> Delete(Courses Course)
    {
        _db.Remove(Course);
        return Save();
    }

    public async Task<IEnumerable<Courses>> GetAll()
    {
        return await _db.Courses.ToListAsync();
    }

    public async Task<Courses> GetByIdAsync(int id)
    {
        return await _db.Courses.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Courses> GetByIdAsyncUntracked(int id)
    {
        return await _db.Courses.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<bool> Save()
    {
        bool saved = await _db.SaveChangesAsync() > 0;
        return saved;
    }

}

