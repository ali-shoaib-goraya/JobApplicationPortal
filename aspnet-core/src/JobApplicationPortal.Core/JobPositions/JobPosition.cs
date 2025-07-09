using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.JobPositions
{
    public class JobPosition : FullAuditedEntity<Guid>
    {
        public int TenantId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
