using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibraryTask.EntityFrameworkCore;
using LibraryTask.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LibraryTask.Web.Tests
{
    [DependsOn(
        typeof(LibraryTaskWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LibraryTaskWebTestModule : AbpModule
    {
        public LibraryTaskWebTestModule(LibraryTaskEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibraryTaskWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LibraryTaskWebMvcModule).Assembly);
        }
    }
}