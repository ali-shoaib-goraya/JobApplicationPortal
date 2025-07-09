using JobApplicationPortal.Configuration.Dto;
using System.Threading.Tasks;

namespace JobApplicationPortal.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
