using Abp.Application.Services.Dto;
using System;

namespace JobApplicationPortal.JobPositions.Dto
{
    public class JobPositionDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
