using Abp.Application.Services.Dto;

namespace JobApplicationPortal.JobPositions.Dto
{
    public class GetAllJobPositionsInput : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
