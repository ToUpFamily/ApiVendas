using Microsoft.EntityFrameworkCore;
using ToUpFamily.Api.Contracts;
using ToUpFamily.Api.Infra.Contexts;
using ToUpFamily.Api.Models;

namespace ToUpFamily.Api.Infra.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApplicationContext _context;

  public UserRepository()
  {
    _context = new ApplicationContext();
  }

  public async Task<bool> CreateAsync(User entity)
  {
    await _context.Users.AddAsync(entity);
    
    var result = await _context.SaveChangesAsync();
    return result > 0;
  }

  public Task DeleteAsync()
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public async Task<IList<User>> GetAllAsync()
  {
    var users = await _context.Users.ToListAsync();
    return users;
  }

  public async Task<User?> GetByIdAsync(int id)
  {
    return await _context.Users.FindAsync(id);
  }

  public async Task<User> UpdateAsync(User entity)
  {
    var result = _context.Update(entity);
    _context.SaveChanges();
    return result.Entity;
  }
}

public interface IUserRepository : IRepository<User>
{}