using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JobApplicationPortal.Authorization;

namespace JobApplicationPortal
{
    [DependsOn(
        typeof(JobApplicationPortalCoreModule),
        typeof(AbpAutoMapperModule)
    )]
    public class JobApplicationPortalApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Register your permissions
            Configuration.Authorization.Providers.Add<JobApplicationPortalAuthorizationProvider>();

            // Register AutoMapper profiles manually if needed (not required if using AddMaps below)
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg =>
                {
                    // Optional: explicit profile registration
                    // cfg.AddProfile<JobPositionMapProfile>();
                });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(JobApplicationPortalApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            // AutoMapper: scan the current assembly for any class that inherits from AutoMapper.Profile
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
