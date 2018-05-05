using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace SIV
{
    public partial class SIV
    {
        #region VARIABLES
        
        #endregion

        #region METHODS

        private void OperatingSystem()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_OperatingSystem");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Windows Name.
                OSName = GetValue(mo, "Caption");
                // Windows Version.
                string temp = GetValue(mo, "Version");
                string[] tempSplit = temp.Split(stopSeperator, StringSplitOptions.RemoveEmptyEntries);
                OSVersion = tempSplit[0] + "." + tempSplit[1];
                // Windows Build Number.
                OSBuildNumber = GetValue(mo, "BuildNumber");
                // Windows Revision Number.
                OSBuildRevision = "";
            }
        }

        #endregion

        #region PROPERTIES
        [Description("Operating System name.")]
        public string OSName { get; set; }

        [Description("Operating System version number.")]
        public string OSVersion { get; set; }

        [Description("Operating System build number.")]
        public string OSBuildNumber { get; set; }

        [Description("Operating System build revision number.")]
        public string OSBuildRevision { get; set; }
        #endregion
    }
}
