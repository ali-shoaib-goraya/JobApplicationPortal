using JobApplicationPortal.Debugging;

namespace JobApplicationPortal;

public class JobApplicationPortalConsts
{
    public const string LocalizationSourceName = "JobApplicationPortal";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "8fb2edf939664e529783faa550ac685b";
}
