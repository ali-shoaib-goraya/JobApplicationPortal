using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using JobApplicationPortal.EntityFrameworkCore.Seed;

namespace JobApplicationPortal.EntityFrameworkCore;

[DependsOn(
    typeof(JobApplicationPortalCoreModule),
    typeof(AbpZeroCoreEntityFrameworkCoreModule))]
public class JobApplicationPortalEntityFrameworkModule : AbpModule
{
    /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<JobApplicationPortalDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    JobApplicationPortalDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    JobApplicationPortalDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(JobApplicationPortalEntityFrameworkModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        if (!SkipDbSeed)
        {
            SeedHelper.SeedHostDb(IocManager);
        }
    }
}
