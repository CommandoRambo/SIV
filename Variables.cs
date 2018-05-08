// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using Microsoft.Win32;

namespace SIV
{
    public partial class SystemInfomation
    {
        private SelectQuery sqlQuery = new SelectQuery();
        private ManagementObjectSearcher moSearcherInfo;
        private static string[] stopSeperator = new String[] { "." };
        private static string nullValue = "Empty or Not Applicable";
        private static string[] sizeSuffix = { "TB", "GB", "MB", "KB", "B", "b" };

        private const string SUBKEY = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\";

        private RegistryKey outputRegKey = Registry.LocalMachine.OpenSubKey(SUBKEY, false);

        private static Dictionary<int, string> dBatteryAvailability = new Dictionary<int, string>();
        private static Dictionary<int, string> dBatteryChemistry = new Dictionary<int, string>();
        private static Dictionary<int, string> dBatteryStatus = new Dictionary<int, string>();
        private static Dictionary<string, string> dCountryCode = new Dictionary<string, string>();
        private static Dictionary<int, string> dCPUStatus = new Dictionary<int, string>();
        private static Dictionary<int, string> dGenuineStatus = new Dictionary<int, string>();
        private static Dictionary<int, string> dLanguage = new Dictionary<int, string>();
        private static Dictionary<string, string> dLicenseChannel = new Dictionary<string, string>();
        private static Dictionary<int, string> dLicenseStatus = new Dictionary<int, string>();
        private static Dictionary<int, string> dLicenseStatusReason = new Dictionary<int, string>();
        private static Dictionary<string, string> dLocale = new Dictionary<string, string>();
        private static Dictionary<int, string> dMemoryFormFactor = new Dictionary<int, string>();
        private static Dictionary<int, string> dMemoryType = new Dictionary<int, string>();
        private static Dictionary<int, string> dOperatingSystemProductSuite = new Dictionary<int, string>();
        private static Dictionary<int, string> dOperatingSystemSKU = new Dictionary<int, string>();
        private static Dictionary<int, string> dOperatingSystemType = new Dictionary<int, string>();
        private static Dictionary<int, string> dProcessorArchitecture = new Dictionary<int, string>();
        private static Dictionary<int, string> dProcessorAvailability = new Dictionary<int, string>();
        private static Dictionary<int, string> dProcessorFamily = new Dictionary<int, string>();
        private static Dictionary<int, string> dProcessorType = new Dictionary<int, string>();
        private static Dictionary<int, string> dProcessorStatusInfo = new Dictionary<int, string>();
        private static Dictionary<int, string> dProductSuite = new Dictionary<int, string>();
        private static Dictionary<int, string> dProductTypes = new Dictionary<int, string>();
        private static Dictionary<int, string> dSuiteMask = new Dictionary<int, string>();
        private static Dictionary<int, string> dSystemType = new Dictionary<int, string>();
        private static Dictionary<int,string> dTypeDetail = new Dictionary<int, string>();
        private static Dictionary<int, string> dUpgradeMethod = new Dictionary<int, string>();
        private static Dictionary<int, string> dVoltageCap = new Dictionary<int, string>();
    }
}