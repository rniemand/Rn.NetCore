using System;

namespace DevConsole.DatabaseTesting;

public class UserEntity
{
  public int UserId { get; set; }
  public bool Deleted { get; set; }
  public DateTime DateCreatedUtc { get; set; } = DateTime.UtcNow;
  public DateTime? DateModified { get; set; }
  public DateTime? LastLoginDate { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string UserEmail { get; set; } = string.Empty;
}
