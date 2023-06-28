using Microsoft.EntityFrameworkCore;
using tankman.Db;
using tankman.Models;
using OneOf;
using tankman.Types;

namespace tankman.Services;

public static class OrgService
{
  public static async Task<OneOf<Org, Error<string>>> CreateOrgAsync(string id)
  {
    if (String.IsNullOrWhiteSpace(id))
    {
      return new Error<string>("name should not be empty.");
    }

    var dbContext = new TankmanDbContext();

    var org = new Org
    {
      Id = id,
      CreatedAt = DateTime.UtcNow,
      Active = true
    };

    dbContext.Orgs.Add(org);
    await dbContext.SaveChangesAsync();

    return org;
  }

  public static async Task<OneOf<List<Org>, Error<string>>> GetOrgsAsync()
  {
    var dbContext = new TankmanDbContext();
    return await dbContext.Orgs.ToListAsync();
  }

  public static async Task<OneOf<Org, Error<string>>> GetOrgAsync(string id)
  {
    var dbContext = new TankmanDbContext();
    return await dbContext.Orgs.SingleAsync((x) => x.Id == id);
  }

  public static async Task<OneOf<Org, Error<string>>> ActivateOrgAsync(string id)
  {
    var dbContext = new TankmanDbContext();
    var org = dbContext.Orgs.Single((x) => x.Id == id);
    org.Active = true;
    await dbContext.SaveChangesAsync();
    return org;
  }

  public static async Task<OneOf<Org, Error<string>>> DeactivateOrgAsync(string id)
  {
    var dbContext = new TankmanDbContext();
    var org = dbContext.Orgs.Single((x) => x.Id == id);
    org.Active = false;
    await dbContext.SaveChangesAsync();
    return org;
  }
}