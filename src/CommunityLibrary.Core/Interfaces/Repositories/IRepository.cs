/// <summary>
/// Defines a generic repository interface for CRUD operations on entities.
/// This interface provides a contract for basic data access operations that can be implemented
/// for any entity type in the system.
/// </summary>
/// <typeparam name="T">The type of entity this repository works with.</typeparam>

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}