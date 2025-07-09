using Abp.Application.Services;
using JobApplicationPortal.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace JobApplicationPortal.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
