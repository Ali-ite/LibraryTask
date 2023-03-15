using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LibraryTask.Configuration.Dto;

namespace LibraryTask.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LibraryTaskAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
