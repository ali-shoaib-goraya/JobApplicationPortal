using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JobApplicationPortal.Candidates.Dto;
using JobApplicationPortal.Roles.Dto;
using System;
using System.Threading.Tasks;

namespace JobApplicationPortal.Candidates
{
    public interface ICandidateAppService : IApplicationService
    {
        Task<ListResultDto<CandidateDto>> GetAllAsync();
        Task CreateAsync(CreateCandidateDto input);

        Task<FileDto> DownloadResumeAsync(Guid id);
    }
}
