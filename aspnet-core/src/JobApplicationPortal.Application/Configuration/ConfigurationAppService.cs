using Abp.Authorization;
using Abp.Runtime.Session;
using JobApplicationPortal.Configuration.Dto;
using System.Threading.Tasks;

namespace JobApplicationPortal.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : JobApplicationPortalAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
