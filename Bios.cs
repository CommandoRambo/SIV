﻿// Copyright © 2018 JRV Solutions.
// Created by Jason Harvey AKA CommandoRambo.
using System;
using System.ComponentModel;
using System.Management;

namespace SIV
{
    public partial class SIV
    {
        private void Bios()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_BIOS");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Manufacturer.
                BiosManufacturer = GetValue(mo, "Manufacturer");

                // Name.
                BiosName = GetValue(mo, "Name");

                // Release date.
                string date = GetValue(mo, "ReleaseDate");
                BiosReleaseDate = ConvertDateTime(date);

                // Serial Number.
                BiosSerialNumber = GetValue(mo, "SerialNumber");

                // Status.
                BiosStatus = GetValue(mo, "Status");

                // Version.
                int major = Convert.ToUInt16(GetValue(mo, "EmbeddedControllerMajorVersion"));
                int minor = Convert.ToUInt16(GetValue(mo, "EmbeddedControllerMinorVersion"));
                BiosVersion = "V" + major.ToString() + "." + minor.ToString("00");
            }
        }

        [Description("Manufacturer of the Bios.")]
        public string BiosManufacturer { get; set; }

        [Description("Name of the Bios.")]
        public string BiosName { get; set; }

        [Description("Release date of the Bios.")]
        public string BiosReleaseDate { get; set; }

        [Description("Serial number of the Bios.")]
        public string BiosSerialNumber { get; set; }

        [Description("Status of the Bios.")]
        public string BiosStatus { get; set; }

        [Description("Version of the Bios.")]
        public string BiosVersion { get; set; }
    }
}