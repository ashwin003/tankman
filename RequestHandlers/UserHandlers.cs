using tankman.Http;
using tankman.Utils;
using tankman.Services;
using tankman.Models;

namespace tankman.RequestHandlers;

public class CreateUser
{
  public required string Id { get; set; }
  public required string IdentityProviderUserId { get; set; }
  public required string IdentityProvider { get; set; }
  public required string Data { get; set; }
}

public class UpdateUser
{
  public required string IdentityProviderUserId { get; set; }
  public required string IdentityProvider { get; set; }
  public required string Data { get; set; }
}


public class AssignRole
{
  public required string RoleId { get; set; }
}

public static class UserHandlers
{
  public static async Task<IResult> GetUsersAsync(string? userId, string orgId, string? sort, string? order, int? from, int? limit)
  {
    SortUserBy? sortBy = sort switch
    {
      "id" => SortUserBy.UserId,
      "createdAt" => SortUserBy.CreatedAt,
      _ => null
    };

    SortOrder? sortOrder = order switch
    {
      "asc" => SortOrder.Ascending,
      "desc" => SortOrder.Descending,
      _ => null
    };

    return ApiResult.ToResult(
      await UserService.GetUsersAsync(userId: userId ?? Settings.Wildcard, orgId: orgId, sortBy: sortBy, sortOrder: sortOrder, from: from, limit: limit),
      (List<User> user) => user.Select(User.ToJson)
    );
  }

  public static async Task<IResult> CreateUserAsync(string orgId, CreateUser createUser)
  {
    return ApiResult.ToResult(
      await UserService.CreateUserAsync(
        userId: createUser.Id,
        identityProviderUserId: createUser.IdentityProviderUserId,
        identityProvider: createUser.IdentityProvider,
        data: createUser.Data,
        orgId: orgId
      ),
      User.ToJson
    );
  }

  public static async Task<IResult> UpdateUserAsync(string userId, string orgId, UpdateUser updateUser)
  {
    return ApiResult.ToResult(
      await UserService.UpdateUserAsync(
        userId: userId,
        identityProviderUserId: updateUser.IdentityProviderUserId,
        identityProvider: updateUser.IdentityProvider,
        data: updateUser.Data,
        orgId: orgId
      ),
      User.ToJson
    );
  }


  public static async Task<IResult> AssignRoleAsync(string userId, string orgId, AssignRole assignRole)
  {
    return ApiResult.ToResult(
      await UserService.AssignRoleAsync(
        roleId: assignRole.RoleId,
        userId: userId,
        orgId: orgId
      ),
      RoleAssignment.ToJson
    );
  }

  public static async Task<IResult> UnassignRoleAsync(string roleId, string userId, string orgId)
  {
    return ApiResult.ToResult(await UserService.UnassignRoleAsync(
      roleId: roleId,
      userId: userId,
      orgId: orgId
    ));
  }

  public static async Task<IResult> DeleteUserAsync(string userId, string orgId)
  {
    return ApiResult.ToResult(await UserService.DeleteUserAsync(
      userId: userId,
      orgId: orgId
    ));
  }
}