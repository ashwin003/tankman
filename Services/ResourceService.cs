using tankman.Models;
using Microsoft.EntityFrameworkCore;
using tankman.Db;
using tankman.Utils;
using OneOf;
using tankman.Types;

namespace tankman.Services;

public static class ResourceService
{
  public static async Task<OneOf<List<Resource>, Error<string>>> GetResourcesAsync(string orgId)
  {
    var dbContext = new TankmanDbContext();
    return await dbContext.Resources.Where((x) => x.OrgId == orgId).ToListAsync();
  }

  public static async Task<OneOf<Resource, Error<string>>> CreateResourceAsync(string resourceId, string orgId)
  {
    var normalizedResourceId = Paths.Normalize(resourceId);

    var dbContext = new TankmanDbContext();
    var resource = new Resource
    {
      Id = normalizedResourceId,
      CreatedAt = DateTime.UtcNow,
      OrgId = orgId,
    };
    dbContext.Resources.Add(resource);
    await dbContext.SaveChangesAsync();
    return resource;
  }

  public static async Task<OneOf<bool, Error<string>>> DeleteResourceAsync(string resourceId, string orgId)
  {
    var normalizedResourceId = Paths.Normalize(resourceId);

    var dbContext = new TankmanDbContext();

    var resource = await dbContext.Resources.SingleAsync((x) => x.Id == normalizedResourceId && x.OrgId == orgId);

    dbContext.Resources.Remove(resource);

    await dbContext.SaveChangesAsync();

    return true;
  }
}
