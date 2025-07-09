using Abp.Application.Services;
using JobApplicationPortal.MultiTenancy.Dto;

namespace JobApplicationPortal.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

