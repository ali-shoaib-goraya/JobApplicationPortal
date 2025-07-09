using System;

namespace JobApplicationPortal.Candidates.Dto
{
    public class CandidateDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ResumePath { get; set; }
        public Guid JobPositionId { get; set; }
    }
}
