using AutoMapper;

namespace JobApplicationPortal.Candidates.Dto
{
    public class CandidateMapProfile : Profile
    {
        public CandidateMapProfile()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CreateCandidateDto, Candidate>()
                .ForMember(x => x.ResumePath, opt => opt.Ignore()) // handled manually
                .ForMember(x => x.Id, opt => opt.Ignore()); // handled by base
        }
    }
}
