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
        internal static string ProcessDir;


        internal static void ReadConfig()
        {
            Configuration.SourceDir        = Properties.Settings.Default.SourceDir;
            Configuration.ProcessDir       = Properties.Settings.Default.ProcessDir;

            Configuration.SourceDir = Environment.ExpandEnvironmentVariables(Configuration.SourceDir);
        }

        internal static void SaveConfig()
        {
            Properties.Settings.Default.SourceDir  = Configuration.SourceDir;
            Properties.Settings.Default.ProcessDir = Configuration.ProcessDir;
            Properties.Settings.Default.Save();
        }
    }
}
