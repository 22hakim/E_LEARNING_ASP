using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using E_Learning_API.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ElearningDataContext _db;

    public TagRepository(ElearningDataContext elearningDataContext)
    {
        _db = elearningDataContext;
    }

    public Task<bool> Add(Tag tag)
    {
        _db.Add(tag);
        return Save();
    }

    public Task<bool> Update(Tag tag)
    {
        _db.Update(tag);
        return Save();
    }

    public Task<bool> Delete(Tag tag)
    {
        _db.Remove(tag);
        return Save();
    }

    public async Task<IEnumerable<Tag>> GetAll() => await _db.Tags.ToListAsync();

    public async Task<Tag?> GetByIdAsync(int id) => await _db.Tags.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<Tag?> GetByIdAsyncUntracked(int id) => await _db.Tags.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

    public async Task<bool> Save()
    {
        bool saved = await _db.SaveChangesAsync() > 0;
        return saved;
    }

}

