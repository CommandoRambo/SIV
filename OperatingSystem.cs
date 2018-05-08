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
                // Name.
                OSName = GetOutput(GetValue(mo, "Caption"));

                // Architecture.
                OSArchitecture = GetOutput(GetValue(mo, "OSArchitecture"));

                // Build Number.
                OSBuildNumber = GetOutput(GetValue(mo, "BuildNumber"));

                // Build Type.
                OSBuildType = GetOutput(GetValue(mo, "BuildType"));

                // Codeset.
                OSCodeSet = GetOutput(GetValue(mo, "CodeSet"));

                // Country Code.
                OSCountryCode = GetOutput(dCountryCode[GetValue(mo, "CountryCode")]);

                // Language.
                OSLanguage = GetOutput(dLanguage[Convert.ToInt32(GetValue(mo, "OSLanguage"))]);

                // Locale.
                OSLocale = GetOutput(dLocale[GetValue(mo, "Locale")]);

                // Manufacturer.
                OSManufacturer = GetOutput(GetValue(mo, "manufacturer"));

                // Product Suite
                OSProductSuite = GetOutput(DecodeProductSuite(Convert.ToInt32(GetValue(mo, "OSProductSuite"))));

                // Product Type.
                OSProductType = GetOutput(dProductTypes[Convert.ToInt32(GetValue(mo, "ProductType"))]);

                // Serial Number.
                OSSerialnumber = GetOutput(GetValue(mo, "SerialNumber"));

                // SKU.
                OSSKU = GetOutput(dOperatingSystemSKU[Convert.ToInt32(GetValue(mo, "OperatingSystemSKU"))]);

                // Status.
                OSStatus = GetOutput(GetValue(mo, "Status"));

                // Suite mask.
                OSSuiteMask = GetOutput(DecodeSuitemask(Convert.ToInt32(GetValue(mo, "SuiteMask"))));

                // Type.
                OSType = GetOutput(dOperatingSystemType[Convert.ToInt16(GetValue(mo, "OSType"))]);

                // Version.
                string temp = GetValue(mo, "Version");
                string[] tempSplit = temp.Split(stopSeperator, StringSplitOptions.RemoveEmptyEntries);
                OSVersion = temp != String.Empty ? tempSplit[0] + "." + tempSplit[1] : nullValue;
            }

            // License.
#if !DEBUG
            sqlQuery = new SelectQuery("SELECT * FROM SoftwareLicensingProduct WHERE NOT PartialProductKey = null AND Description > 'Operating System'");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Genuine Status.
                OSGenuineStatus = GetOutput(dGenuineStatus[Convert.ToInt32(GetValue(mo, "GenuineStatus"))]);

                // License Type.
                string temp = GetValue(mo, "Description").Replace("channel","");
                string[] tempSplit = temp.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                OSLicenseType = GetOutput(dLicenseChannel[tempSplit[1].Replace(" ","")]);

                // License Status.
                OSLicenseStatus = GetOutput(dLicenseStatus[Convert.ToInt32(GetValue(mo, "LicenseStatus"))]);

                // License Status reason.
                OSLicenseStatusReason = GetOutput(dLicenseStatusReason[Convert.ToInt32(GetValue(mo, "LicenseStatusReason"))]);

                // Product Key Channel.
                OSProductKeyChannel = GetOutput(GetValue(mo, "ProductKeyChannel"));
            }


            // Release Id.
            OSReleaseId = GetOutput(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default).OpenSubKey(SUBKEY).GetValue("ReleaseId").ToString());

            // Revision Number.
            OSBuildRevision = GetOutput(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default).OpenSubKey(SUBKEY).GetValue("UBR").ToString());

            // Product Key.
            OSProductKey = GetOutput(Decode(GetProductKey("DigitalProductId")));
#endif
        }
        #endregion

        #region PROPERTIES
        [Description("Operating system instance within a computer system.")]
        public string OSName { get; set; }

        [Description("Architecture of the operating system, as opposed to the processor.")]
        public string OSArchitecture { get; set; }

        [Description("Build number of an operating system.")]
        public string OSBuildNumber { get; set; }

        [Description("Revision number of an operating system.")]
        public string OSBuildRevision { get; set; }

        [Description("Type of build used for an operating system.")]
        public string OSBuildType { get; set; }

        [Description("Code page value an operating system uses.")]
        public string OSCodeSet { get; set; }

        [Description("Code for the country/region that an operating system uses.")]
        public string OSCountryCode { get; set; }

        [Description("Specifies the genuine status for the product application.")]
        public string OSGenuineStatus { get; set; }

        [Description("Language version of the operating system installed.")]
        public string OSLanguage { get; set; }

        [Description("Specifies the license type of this product application.")]
        public string OSLicenseType { get; set; }

        [Description("Specifies the license status of this product application.")]
        public string OSLicenseStatus { get; set; }

        [Description("Specifies the license status.")]
        public string OSLicenseStatusReason { get; set; }

        [Description("Language identifier used by the operating system.")]
        public string OSLocale { get; set; }

        [Description("Name of the operating system manufacturer.")]
        public string OSManufacturer { get; set; }

        [Description("Get the Product Key.")]
        public string OSProductKey { get; set; }

        [Description("Specifies the product key channel.")]
        public string OSProductKeyChannel { get; set; }

        [Description("Installed and licensed system product additions to the operating system.")]
        public string OSProductSuite { get; set; }

        [Description("Additional system information.")]
        public string OSProductType { get; set; }

        [Description("The release Id of an operating system.")]
        public string OSReleaseId { get; set; }

        [Description("Operating system product serial identification number.")]
        public string OSSerialnumber { get; set; }

        [Description("Stock Keeping Unit (SKU) number for the operating system.")]
        public string OSSKU { get; set; }

        [Description("Current status of the object.")]
        public string OSStatus { get; set; }

        [Description("Bit flags that identify the product suites available on the system.")]
        public string OSSuiteMask { get; set; }

        [Description("Type of operating system.")]
        public string OSType { get; set; }

        [Description("Version number of the operating system.")]
        public string OSVersion { get; set; }
        #endregion
    }
}
