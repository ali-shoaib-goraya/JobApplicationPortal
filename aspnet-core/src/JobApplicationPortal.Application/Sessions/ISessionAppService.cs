using Abp.Application.Services;
using JobApplicationPortal.Sessions.Dto;
using System.Threading.Tasks;

namespace JobApplicationPortal.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
