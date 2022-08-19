using System;
using E_Learning_API.Models;

namespace E_Learning_API.Interfaces;


public interface ICoursesRepository
{
    Task<IEnumerable<Courses>> GetAll();

    Task<Courses> GetByIdAsync(int id);

    Task<Courses> GetByIdAsyncUntracked(int id);

    Task<bool> Add(Courses Course);

    Task<bool> Update(Courses Course);

    Task<bool> Delete(Courses Course);

    Task<bool> Save();
}

