using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.Candidates
{
    public class Candidate : FullAuditedEntity<Guid>
    {
        public int TenantId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string ResumePath { get; set; }  // file path saved

        public Guid JobPositionId { get; set; }
    }
}
