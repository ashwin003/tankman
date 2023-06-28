using tankman.Services;
using tankman.Http;

namespace tankman.RequestHandlers;

public class CreateOrg
{
  public required string Id { get; set; }
}

public class PatchOrg
{
  public required string Op { get; set; }
}

public static class OrgHandlers
{
  public static async Task<IResult> GetOrgsAsync()
  {
    return ApiResult.ToResult(await OrgService.GetOrgsAsync());
  }

  public static async Task<IResult> CreateOrgAsync(CreateOrg org)
  {
    return ApiResult.ToResult(await OrgService.CreateOrgAsync(org.Id));
  }

  public static async Task<IResult> GetOrgAsync(string orgId)
  {
    return ApiResult.ToResult(await OrgService.GetOrgAsync(orgId));
  }


  public static async Task<IResult> DeleteOrgAsync(string orgId)
  {
    return ApiResult.ToResult(await OrgService.DeleteOrgAsync(orgId));
  }
}