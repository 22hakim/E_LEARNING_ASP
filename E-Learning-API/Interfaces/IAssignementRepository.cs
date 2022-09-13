using E_Learning_API.Models;

namespace E_Learning_API.Interfaces;


public interface IAssignementRepository
{

    Task<Assignement?> GetByIdAsync(int id);

    Task<Assignement?> GetByIdAsyncUntracked(int id);

    Task<bool> Add(Assignement assignement);

    Task<bool> Update(Assignement assignement);

    Task<bool> Delete(Assignement assignement);

    Task<bool> Save();
}

