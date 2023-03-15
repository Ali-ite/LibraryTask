using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibraryTask.Configuration;

namespace LibraryTask.Web.Host.Startup
{
    [DependsOn(
       typeof(LibraryTaskWebCoreModule))]
    public class LibraryTaskWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibraryTaskWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibraryTaskWebHostModule).GetAssembly());
        }
    }
}
