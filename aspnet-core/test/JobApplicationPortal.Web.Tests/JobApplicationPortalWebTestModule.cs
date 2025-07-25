﻿using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JobApplicationPortal.EntityFrameworkCore;
using JobApplicationPortal.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace JobApplicationPortal.Web.Tests;

[DependsOn(
    typeof(JobApplicationPortalWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class JobApplicationPortalWebTestModule : AbpModule
{
    public JobApplicationPortalWebTestModule(JobApplicationPortalEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(JobApplicationPortalWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(JobApplicationPortalWebMvcModule).Assembly);
    }
}