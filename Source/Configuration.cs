using PrintTextToPicture.Properties;
using System;

namespace PrintTextToPicture
{
    public static class Configuration
    {
        internal static string SourceDir;
        internal static string ProcessDir;
        internal static bool   OverrideDestination;

        internal static void ReadConfig()
        {
            Configuration.SourceDir           = Settings.Default.SourceDir;
            Configuration.ProcessDir          = Settings.Default.ProcessDir;
            Configuration.OverrideDestination = Settings.Default.OverrideDestination;    

            Configuration.SourceDir = Environment.ExpandEnvironmentVariables(Configuration.SourceDir);
        }

        internal static void SaveConfig()
        {
            Settings.Default.SourceDir           = Configuration.SourceDir;
            Settings.Default.ProcessDir          = Configuration.ProcessDir;
            Settings.Default.OverrideDestination = Configuration.OverrideDestination;
            Settings.Default.Save();
        }
    }
}
