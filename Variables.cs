﻿using System;
using System.Collections.Generic;
using System.Management;

namespace SIV
{
    public partial class SIV
    {
        private SelectQuery sqlQuery = new SelectQuery();
        private ManagementObjectSearcher moSearcherInfo;
        private string[] stopSeperator = new String[] { "." };



        private Dictionary<int, string> dProductTypes = new Dictionary<int, string>();
        private Dictionary<int, string> dSystemType = new Dictionary<int, string>();
        private Dictionary<int, string> dGenuineStatus = new Dictionary<int, string>();
        private Dictionary<int, string> dOperatingSystemSKU = new Dictionary<int, string>();
        private Dictionary<string, string> dLocale = new Dictionary<string, string>();
        private Dictionary<int, string> dLanguage = new Dictionary<int, string>();
        private Dictionary<int, string> dOperatingSystemType = new Dictionary<int, string>();
        private Dictionary<int, string> dCountryCode = new Dictionary<int, string>();
        private Dictionary<int, string> dOperatingSystemProductSuite = new Dictionary<int, string>();
        private Dictionary<int, string> dSuiteMask = new Dictionary<int, string>();
        private Dictionary<string, string> dLicenseChannel = new Dictionary<string, string>();
        private Dictionary<int,string> dBatteryAvailability = new Dictionary<int, string>();
        private Dictionary<int,string> dBatteryStatus = new Dictionary<int, string>();
        private Dictionary<int,string> dBatteryChemistry = new Dictionary<int, string>();
    }
}