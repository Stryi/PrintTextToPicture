using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace PrintTextToPicture
{
    public static class Configuration
    {
        internal static string SourceDir;
        internal static bool   ProcessSubFolder = true;


        internal static void ReadConfig()
        {
            Configuration.SourceDir = ConfigurationManager.AppSettings["SourceDir"];
            Configuration.ProcessSubFolder = bool.Parse(ConfigurationManager.AppSettings["ProcessSubFolder"]);

            Configuration.SourceDir = Environment.ExpandEnvironmentVariables(Configuration.SourceDir);
        }

        internal static void SaveConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["SourceDir"].Value = Configuration.SourceDir;
            config.AppSettings.Settings["ProcessSubFolder"].Value = Configuration.ProcessSubFolder.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
