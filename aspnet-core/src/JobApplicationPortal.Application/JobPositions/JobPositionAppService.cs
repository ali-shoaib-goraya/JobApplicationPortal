using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using JobApplicationPortal.Authorization;
using JobApplicationPortal.JobPositions.Dto;
using System;
using JobApplicationPortal.JobPositions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;

namespace JobApplicationPortal.JobPositions
{
    //[AbpAuthorize(PermissionNames.Pages_JobPositions)]
    public class JobPositionAppService : AsyncCrudAppService<
        JobPosition, JobPositionDto, Guid, GetAllJobPositionsInput,
        CreateJobPositionDto, UpdateJobPositionDto>, IJobPositionAppService
    {
        public JobPositionAppService(IRepository<JobPosition, Guid> repository)
            : base(repository)
        {
        }

        // Override CreateAsync to set TenantId manually (important!)
        public override async Task<JobPositionDto> CreateAsync(CreateJobPositionDto input)
        {
            var entity = ObjectMapper.Map<JobPosition>(input);
            entity.TenantId = AbpSession.TenantId ?? throw new Exception("TenantId is null");

            await Repository.InsertAsync(entity);
            return MapToEntityDto(entity);
        }


        public override async Task<PagedResultDto<JobPositionDto>> GetAllAsync(GetAllJobPositionsInput input)
        {
            var query = Repository.GetAll();

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x => x.Title.Contains(input.Keyword) || x.Description.Contains(input.Keyword));
            }

            var totalCount = await query.CountAsync();

            // Fix for CS0411: Explicitly specify the type arguments for OrderBy
            var items = await query
                .OrderBy(x => EF.Property<object>(x, input.Sorting ?? "Title")) // Explicitly use EF.Property for dynamic sorting
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<JobPositionDto>(
                totalCount,
                ObjectMapper.Map<List<JobPositionDto>>(items)
            );
        }


    }
}
