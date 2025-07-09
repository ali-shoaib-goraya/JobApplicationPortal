using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace JobApplicationPortal.Localization;

public static class JobApplicationPortalLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(JobApplicationPortalConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(JobApplicationPortalLocalizationConfigurer).GetAssembly(),
                    "JobApplicationPortal.Localization.SourceFiles"
                )
            )
        );
    }
}
