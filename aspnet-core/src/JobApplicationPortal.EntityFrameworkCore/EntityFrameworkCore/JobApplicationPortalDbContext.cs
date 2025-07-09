using Abp.Zero.EntityFrameworkCore;
using JobApplicationPortal.Authorization.Roles;
using JobApplicationPortal.Authorization.Users;
using JobApplicationPortal.Candidates;
using JobApplicationPortal.JobPositions;
using JobApplicationPortal.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationPortal.EntityFrameworkCore;

public class JobApplicationPortalDbContext : AbpZeroDbContext<Tenant, Role, User, JobApplicationPortalDbContext>
{
    /* Define a DbSet for each entity of the application */
    public JobApplicationPortalDbContext(DbContextOptions<JobApplicationPortalDbContext> options)
        : base(options)
    {

    }

    public DbSet<JobPosition> JobPositions { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
}
