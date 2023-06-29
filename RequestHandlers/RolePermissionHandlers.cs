using tankman.Http;
using tankman.Models;
using tankman.Services;
using tankman.Types;

namespace tankman.RequestHandlers;

public class CreateRolePermission
{
  public required string ResourceId { get; set; }
  public required string RoleId { get; set; }
  public required string Action { get; set; }
}

public static class RolePermissionHandlers
{
  public static async Task<IResult> GetRolePermissionsAsync(string orgId, string roleId, string action, string resourceId)
  {
    return ApiResult.ToResult(await RolePermissionService.GetRolePermissionsAsync(
      roleId: roleId,
      resourceId: resourceId,
      action: action,
      orgId: orgId
    ));
  }

  public static async Task<IResult> CreateRolePermissionAsync(string orgId, CreateRolePermission createPermission)
  {
    return ApiResult.ToResult(await RolePermissionService.CreateRolePermissionAsync(
      roleId: createPermission.RoleId,
      resourceId: createPermission.ResourceId,
      action: createPermission.Action, 
      orgId: orgId
    ));
  }

  public static async Task<IResult> DeleteRolePermissionAsync(string roleId, string resourceId, string action, string orgId)
  {
    return ApiResult.ToResult(await RolePermissionService.DeleteRolePermissionsAsync(
      roleId:roleId, 
      resourceId:resourceId, 
      action:action, 
      orgId:orgId
    ));
  }
}