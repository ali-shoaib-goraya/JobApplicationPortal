using Abp.Application.Services;
using JobApplicationPortal.JobPositions.Dto;
using System;

namespace JobApplicationPortal.JobPositions
{
    public interface IJobPositionAppService : IAsyncCrudAppService<
        JobPositionDto, Guid, GetAllJobPositionsInput,
        CreateJobPositionDto, UpdateJobPositionDto>
    {
    }
}
