using System.Threading.Tasks;
using LibraryTask.Configuration.Dto;

namespace LibraryTask.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
