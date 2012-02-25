using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TaskPanel.UI
{
    public static class VersionInfo
    {
        private static Version version = new Version(1, 0, 2);
        private static DateTime buildDate = new DateTime(2011, 12, 19);

        /// <summary>
        /// Current version
        /// </summary>
        public static Version Version
        {
            get
            {
                if (version.Revision == -1)
                {
                    int revision = Assembly.GetExecutingAssembly().GetName().Version.Revision;
                    version = new Version(version.Major, version.Minor, version.Build, revision);
                }
                return version;
            }
        }

        /// <summary>
        /// Build date
        /// </summary>
        public static DateTime BuildDate
        {
            get
            {
                return buildDate;
            }
        }
    }
}
