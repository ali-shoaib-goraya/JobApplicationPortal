using Abp.AspNetCore.Mvc.Controllers;
using JobApplicationPortal.Candidates;
using JobApplicationPortal.Candidates.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JobApplicationPortal.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CandidateDownloadController : AbpController
    {
        private readonly ICandidateAppService _candidateAppService;

        public CandidateDownloadController(ICandidateAppService candidateAppService)
        {
            _candidateAppService = candidateAppService;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadResume(Guid id)
        {
            FileDto file = await _candidateAppService.DownloadResumeAsync(id);
            return File(file.FileBytes, file.FileType, file.FileName);
        }
    }
}
