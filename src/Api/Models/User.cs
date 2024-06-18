using System.Globalization;

namespace ToUpFamily.Api.Models;

public class User(string name, string lastName, string email, string? birthday) : BaseModel
{
  public string Name { get; private set; } = name;
  public string LastName { get; private set; } = lastName;
  public string Email { get; private set; } = email;
  public string? Birthday { get; private set; } = birthday;
  public bool IsActive { get; private set; }

  public void Activate() => IsActive = true;
  public void Deactivate() => IsActive = false;
}