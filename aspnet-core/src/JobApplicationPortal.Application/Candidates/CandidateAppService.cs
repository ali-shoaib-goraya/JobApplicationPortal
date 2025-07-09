using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.MimeTypes;
using Abp.UI;
using JobApplicationPortal.Authorization;
using JobApplicationPortal.Candidates.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationPortal.Candidates
{
    [AbpAuthorize]
    public class CandidateAppService : ApplicationService, ICandidateAppService
    {
        private readonly IRepository<Candidate, Guid> _repository;
        private readonly IWebHostEnvironment _env;

        public CandidateAppService(IRepository<Candidate, Guid> repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        //[AbpAuthorize(PermissionNames.Candidates_View)]
        public async Task<ListResultDto<CandidateDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllListAsync();
            return new ListResultDto<CandidateDto>(ObjectMapper.Map<List<CandidateDto>>(entities));
        }

        //[AbpAuthorize(PermissionNames.Candidates_Create)]
        public async Task CreateAsync(CreateCandidateDto input)
        {
            // validate file
            var allowedExts = new[] { ".pdf", ".docx", ".jpg", ".jpeg", ".png" };
            var fileExt = Path.GetExtension(input.ResumeFile.FileName).ToLower();

            if (!allowedExts.Contains(fileExt))
                throw new UserFriendlyException("Invalid file type.");

            var fileName = Guid.NewGuid() + fileExt;
            var path = Path.Combine(_env.WebRootPath, "uploads", "resumes");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await input.ResumeFile.CopyToAsync(stream);
            }

            var entity = ObjectMapper.Map<Candidate>(input);
            entity.ResumePath = $"/uploads/resumes/{fileName}";
            entity.TenantId = AbpSession.TenantId ?? throw new Exception("TenantId is null");

            await _repository.InsertAsync(entity);
        }


        //[AbpAuthorize(PermissionNames.Candidates_View)]
        public async Task<FileDto> DownloadResumeAsync(Guid id)
        {
            var candidate = await _repository.GetAsync(id);

            if (string.IsNullOrEmpty(candidate.ResumePath))
            {
                throw new UserFriendlyException("Resume not found for this candidate.");
            }

            var fullPath = Path.Combine(_env.WebRootPath, candidate.ResumePath.TrimStart('/'));
            if (!File.Exists(fullPath))
            {
                throw new UserFriendlyException("Resume file is missing on the server.");
            }

            var fileBytes = await File.ReadAllBytesAsync(fullPath);
            var fileName = Path.GetFileName(fullPath);

            return new FileDto
            {
                FileName = fileName,
                FileType = JobApplicationPortal.Net.MimeTypes.MimeTypeMap.GetMimeType(Path.GetExtension(fileName)),
                FileBytes = fileBytes
            };
        }

    }
}
