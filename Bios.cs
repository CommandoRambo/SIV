// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License
using System;
using System.ComponentModel;
using System.Management;

namespace SIV
{
    public partial class SystemInfomation
    {
        private void Bios()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_BIOS");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Manufacturer.
                BiosManufacturer = GetOutput(GetValue(mo, "Manufacturer"));

                // Release date.
                BiosReleaseDate = GetOutput(ConvertDateTime(GetValue(mo, "ReleaseDate")));

                // Serial Number.
                BiosSerialNumber = GetOutput(GetValue(mo, "SerialNumber"));

                // Status.
                BiosStatus = GetOutput(GetValue(mo, "Status"));

                // Version.
                int major = Convert.ToUInt16(GetValue(mo, "EmbeddedControllerMajorVersion"));
                int minor = Convert.ToUInt16(GetValue(mo, "EmbeddedControllerMinorVersion"));
                BiosVersion = "V" + major.ToString() + "." + minor.ToString("00");

                // Name.
                BiosName = GetOutput(GetValue(mo, "Name"));
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