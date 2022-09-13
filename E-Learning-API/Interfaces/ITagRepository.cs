using E_Learning_API.Models;

namespace E_Learning_API.Interfaces;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAll();

    Task<Tag?> GetByIdAsync(int id);

    Task<Tag?> GetByIdAsyncUntracked(int id);

    Task<bool> Add(Tag tag);

    Task<bool> Update(Tag tag);

    Task<bool> Delete(Tag tag);

    Task<bool> Save();
}

