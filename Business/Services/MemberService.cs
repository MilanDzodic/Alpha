using System.Diagnostics;
using Business.Models;
using Data.Entities;
using Data.Repositories;
using Domain.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public interface IMemberService
{
  Task<MemberResult> AddMemberToRole(string memberId, string roleName);
  Task<MemberResult> CreateUserAsync(MemberSignUpForm form, string roleName = "Member");
  Task<MemberResult> GetMembersAsync();
}

public class MemberService(IMemberRepository memberRepository, UserManager<MemberEntity> userManager, RoleManager<IdentityRole> roleManager) : IMemberService
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

  public async Task<MemberResult> CreateUserAsync(MemberSignUpForm form, string roleName = "Member")
  {
    if (form == null)
      return new MemberResult { Succeeded = false, StatusCode = 400, Error = "Form data cant be null" };

    var existsResult = await _memberRepository.ExistsAsync(x => x.Email == form.Email);
    if (existsResult.Succeeded)
      return new MemberResult { Succeeded = false, StatusCode = 409, Error = "User with same email already exists" };

    try
    {
      var memberEntity = form.MapTo<MemberEntity>();

      var result = await _userManager.CreateAsync(memberEntity, form.Password);
      
      if (result.Succeeded)
      {
        var addToRoleResult = await AddMemberToRole(memberEntity.Id, roleName);
        return result.Succeeded
          ? new MemberResult { Succeeded = true, StatusCode = 201 }
          : new MemberResult { Succeeded = false, StatusCode = 201, Error = "Member created but not added to role" };
      }

      return new MemberResult { Succeeded = false, StatusCode = 500, Error = "Unable to create user" };
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex);
      return new MemberResult { Succeeded = false, StatusCode = 500, Error = ex.Message };
    }
  }
}
