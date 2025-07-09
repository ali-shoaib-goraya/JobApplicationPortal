using Abp.Modules;
using Abp.Reflection.Extensions;
using JobApplicationPortal.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace JobApplicationPortal.Web.Host.Startup
{
    [DependsOn(
       typeof(JobApplicationPortalWebCoreModule))]
    public class JobApplicationPortalWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JobApplicationPortalWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JobApplicationPortalWebHostModule).GetAssembly());
        }
    }
}
