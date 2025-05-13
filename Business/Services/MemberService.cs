using Business.Models;
using Data.Entities;
using Data.Repositories;
using Domain.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public interface IMemberService
{
  Task<MemberResult> AddMemberToRole(string memberId, string roleName);
  Task<MemberResult> GetMembersAsync();
}

public class MemberService(IMemberRepository memberRepository, UserManager<MemberEntity> userManager, RoleManager<IdentityRole> roleManager) : IMemberService, IMemberService
{
  private readonly IMemberRepository _memberRepository = memberRepository;
  private readonly UserManager<MemberEntity> _userManager = userManager;
  private readonly RoleManager<IdentityRole> _roleManager = roleManager;

  public async Task<MemberResult> GetMembersAsync()
  {
    var result = await _memberRepository.GetAllAsync();
    return result.MapTo<MemberResult>();
  }

  public async Task<MemberResult> AddMemberToRole(string memberId, string roleName)
  {

    if (!await _roleManager.RoleExistsAsync(roleName))
      return new MemberResult { Succeeded = false, StatusCode = 404, Error = "Role doesn't exists." };

    var user = await _userManager.FindByIdAsync(memberId);
    if (user == null)
      return new MemberResult { Succeeded = false, StatusCode = 404, Error = "User doesn't exists." };

    var result = await _userManager.AddToRoleAsync(user, roleName);
    return result.Succeeded
      ? new MemberResult { Succeeded = true, StatusCode = 200 }
      : new MemberResult { Succeeded = false, StatusCode = 500, Error = "Unable to add user to role." };
  }
}
