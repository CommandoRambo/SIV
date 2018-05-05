// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;

namespace SIV
{
    public partial class SystemInfomation
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
                OSName = GetOutput(GetValue(mo, "Caption"));

                // Windows Version.
                string temp = GetValue(mo, "Version");
                string[] tempSplit = temp.Split(stopSeperator, StringSplitOptions.RemoveEmptyEntries);
                
                OSVersion = temp != String.Empty ? tempSplit[0] + "." + tempSplit[1] : nullValue;

                // Windows Build Number.
                OSBuildNumber = GetOutput(GetValue(mo, "BuildNumber"));

            }

            // Windows Revision Number.
            OSBuildRevision = GetOutput(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default).OpenSubKey(SUBKEY).GetValue("UBR").ToString());
            
            // Product Key.
            OSProductKey = GetOutput(Decode(GetProductKey("DigitalProductId")));
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

        [Description("Get the Product Key.")]
        public string OSProductKey { get; set; }
        #endregion
    }
}
