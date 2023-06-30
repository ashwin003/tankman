using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tankman.Models;

public class UserJson
{
  public required string Id { get; set; }
  public required string Data { get; set; }
  public required string IdentityProvider { get; set; }
  public required string IdentityProviderUserId { get; set; }
  public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public required string OrgId { get; set; }
  public List<string> Roles { get; set; } = new List<string>();
  public required Dictionary<string, string> Properties { get; set; }
}


[PrimaryKey(nameof(Id), nameof(OrgId))]
public class User : IEntity, IOrgAssociated
{
  public required string Id { get; set; }

  public required string Data { get; set; }

  public required string IdentityProvider { get; set; }

  public required string IdentityProviderUserId { get; set; }

  public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public required string OrgId { get; set; }
  [ForeignKey(nameof(OrgId))]
  public Org? Org { get; set; } = null;

  [NotMapped]
  public List<string> Roles { get; set; } = new List<string>();

  public List<RoleAssignment> RoleAssignments { get; set; } = new List<RoleAssignment>();

  public List<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

  public List<UserProperty> Properties { get; set; } = new List<UserProperty>();

  public static UserJson ToJson(User entity)
  {
    var properties = new Dictionary<string, string>();

    foreach (var property in entity.Properties)
    {
      properties[property.Name] = property.Value;
    }

    return new UserJson
    {
      Id = entity.Id,
      Data = entity.Data,
      IdentityProvider = entity.IdentityProvider,
      IdentityProviderUserId = entity.IdentityProviderUserId,
      CreatedAt = entity.CreatedAt,
      OrgId = entity.OrgId,
      Roles = entity.Roles,
      Properties = properties
    };
  }
}