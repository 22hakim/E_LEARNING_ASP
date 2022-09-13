using E_Learning_API.Models;

namespace E_Learning_API.Interfaces;


public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAll();

    Task<Course?> GetByIdAsync(int id);

    Task<Course?> GetByIdAsyncUntracked(int id);

    Task<bool> Add(Course Course);

    Task<bool> Update(Course Course);

    Task<bool> Delete(Course Course);

    Task<bool> Save();
}

