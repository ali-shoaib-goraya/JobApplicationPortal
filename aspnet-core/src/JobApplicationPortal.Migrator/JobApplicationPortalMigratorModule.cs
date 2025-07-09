using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JobApplicationPortal.Configuration;
using JobApplicationPortal.EntityFrameworkCore;
using JobApplicationPortal.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace JobApplicationPortal.Migrator;

[DependsOn(typeof(JobApplicationPortalEntityFrameworkModule))]
public class JobApplicationPortalMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public JobApplicationPortalMigratorModule(JobApplicationPortalEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(JobApplicationPortalMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            JobApplicationPortalConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(JobApplicationPortalMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
