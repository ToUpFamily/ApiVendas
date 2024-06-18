using ToUpFamily.Api.Models;

namespace ToUpFamily.Api.Contracts;

public interface IRepository<T> where T : BaseModel
{
  Task<bool> CreateAsync(T entity);
  Task<IList<T>> GetAllAsync();
  Task<T?> GetByIdAsync(int id);
  Task<T> UpdateAsync(T entity);
  Task DeleteAsync();
  Task DeleteAsync(int id);
}