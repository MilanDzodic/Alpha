using Business.Models;
using Data.Repositories;
using Domain.Extensions;

namespace Business.Services;

public interface IStatusService
{
  Task<StatusResult> GetStatusByIdAsync(int id);
  Task<StatusResult> GetStatusByNameAsync(string statusName);
  Task<StatusResult> GetStatusesAsync();
}

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
  private readonly IStatusRepository _statusRepository = statusRepository;

  public async Task<StatusResult> GetStatusesAsync()
  {
    var result = await _statusRepository.GetAllAsync();
    return result.MapTo<StatusResult>();
  }
  
  public async Task<StatusResult> GetStatusByNameAsync(string statusName)
  {
    var result = await _statusRepository.GetAsync(x => x.StatusName == statusName); 
    return result.MapTo<StatusResult>();
  }

  public async Task<StatusResult> GetStatusByIdAsync(int id)
  {
    var result = await _statusRepository.GetAsync(x => x.Id == id);
    return result.MapTo<StatusResult>();
  }
}
