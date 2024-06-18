using Microsoft.EntityFrameworkCore;
using ToUpFamily.Api.Models;

namespace ToUpFamily.Api.Infra.Contexts;

public class ApplicationContext : DbContext
{
  public DbSet<User> Users { get; set; }

  public string DbPath {get;}

  public ApplicationContext()
  {
    var path = Directory.GetCurrentDirectory();
    DbPath = Path.Join(path, "toupfamily.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}