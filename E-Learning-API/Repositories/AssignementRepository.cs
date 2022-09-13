using E_Learning_API.Data;
using E_Learning_API.Models;
using E_Learning_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Repositories;

public class AssignementRepository : IAssignementRepository
{
    private readonly ElearningDataContext _db;

    public AssignementRepository(ElearningDataContext elearningDataContext)
    {
        _db = elearningDataContext;
    }

    public Task<bool> Add(Assignement assignement)
    {
        _db.Add(assignement);
        return Save();
    }

    public Task<bool> Update(Assignement assignement)
    {
        _db.Update(assignement);
        return Save();
    }

    public Task<bool> Delete(Assignement assignement)
    {
        _db.Remove(assignement);
        return Save();
    }

    public async Task<Assignement?> GetByIdAsync(int id) => await _db.Assignements.FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Assignement?> GetByIdAsyncUntracked(int id) => await _db.Assignements.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);


    public async Task<bool> Save()
    {
        bool saved = await _db.SaveChangesAsync() > 0;
        return saved;
    }

}

