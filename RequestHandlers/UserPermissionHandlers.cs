using tankman.Http;
using tankman.Utils;
using tankman.Services;

namespace tankman.RequestHandlers;

public class CreateUserPermission
{
  public required string ResourceId { get; set; }
  public required string UserId { get; set; }
  public required string Action { get; set; }
}

public static class UserPermissionHandlers
{
  public static async Task<IResult> GetUserPermissionsAsync(string orgId, string userId, string? action, string? resourceId, int? from, int? limit)
  {
    return ApiResult.ToResult(await UserPermissionService.GetUserPermissionsAsync(
      resourceId: resourceId ?? "/" + Settings.Wildcard,
      action: action ?? Settings.Wildcard,
      userId: userId,
      orgId: orgId,
      from: from,
      limit: limit
    ));
  }

  public static async Task<IResult> GetEffectivePermissionsAsync(string orgId, string userId, string? action, string? resourceId, int? from, int? limit)
  {
    return ApiResult.ToResult(await UserPermissionService.GetEffectivePermissionsAsync(
      resourceId: resourceId ?? "/" + Settings.Wildcard,
      action: action ?? Settings.Wildcard,
      userId: userId,
      orgId: orgId,
      from: from,
      limit: limit
    ));
  }

  public static async Task<IResult> CreateUserPermissionAsync(string orgId, CreateUserPermission createPermission)
  {
    return ApiResult.ToResult(await UserPermissionService.CreateUserPermissionAsync(
      userId: createPermission.UserId,
      resourceId: createPermission.ResourceId,
      action: createPermission.Action,
      orgId: orgId
    ));
  }

  public static async Task<IResult> DeleteUserPermissionAsync(string orgId, string userId, string action, string resourceId)
  {
    return ApiResult.ToResult(await UserPermissionService.DeleteUserPermissionsAsync(
      resourceId: resourceId,
      action: action,
      userId: userId,
      orgId: orgId
    ));
  }
}