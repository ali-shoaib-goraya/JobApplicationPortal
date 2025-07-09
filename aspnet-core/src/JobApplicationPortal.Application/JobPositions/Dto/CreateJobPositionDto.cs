using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.JobPositions.Dto
{
    public class CreateJobPositionDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
