using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace JobApplicationPortal.Candidates.Dto
{
    public class CreateCandidateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Guid JobPositionId { get; set; }

        [Required]
        public IFormFile ResumeFile { get; set; }
    }
}
