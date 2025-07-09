using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.JobPositions.Dto
{
    public class UpdateJobPositionDto : EntityDto<Guid>  // ✅ FIX: Inherit from EntityDto<Guid>
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
