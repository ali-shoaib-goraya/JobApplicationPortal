using AutoMapper;
using JobApplicationPortal.JobPositions.Dto;

namespace JobApplicationPortal.JobPositions.Dto
{
    public class JobPositionMapProfile : Profile
    {
        public JobPositionMapProfile()
        {
            CreateMap<JobPosition, JobPositionDto>();
            CreateMap<CreateJobPositionDto, JobPosition>();
            CreateMap<UpdateJobPositionDto, JobPosition>();
        }
    }
}
