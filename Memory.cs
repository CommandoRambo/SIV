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
        private void Memory()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_PhysicalMemory");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Attributes.
                PMAttributes = GetOutput(GetValue(mo, "Attributes"));

                // Bank Label.
                PMBankLabel = GetOutput(GetValue(mo, "bankLabel"));

                // Capacity.
                PMCapacity = GetOutput(ReadableSize(Convert.ToInt64(GetValue(mo, "Capacity"))));

                // Configured Clock Speed.
                PMConfiguredClockSpeed = GetOutput(GetValue(mo, "ConfiguredClockSpeed"));

                // Device Locator.
                PMDeviceLocator = GetOutput(GetValue(mo, "DeviceLocator"));

                // Form Factor.
                PMFormFactor = GetOutput(dMemoryFormFactor[Convert.ToInt16(GetValue(mo, "FormFactor"))]);

                // Manufacturer.
                PMManufacturer = GetOutput(GetValue(mo, "Manufacturer"));

                // Memory Type.
                PMMemoryType = GetOutput(dMemoryType[Convert.ToInt16(GetValue(mo, "MemoryType"))]);

                // Name.
                PMName = GetOutput(GetValue(mo, "Name"));

                // Part Number.
                PMPartNumber = GetOutput(GetValue(mo, "PartNumber"));

                // Serial Number;
                PMSerialNumber = GetOutput(GetValue(mo, "SerialNumber"));

                // Speed.
                PMSpeed = GetOutput(GetValue(mo, "Soeed"));

                // Status.
                PMStatus = GetOutput(GetValue(mo, "Status"));

                // Type detail.
                PMTypeDetail = GetOutput(DecodeTypeDetail(Convert.ToInt16(GetValue(mo, "TypeDetail"))));

                // Version.
                PMVersion = GetOutput(GetValue(mo, "Version"));


            }
        }

        [Description("SMBIOS - Type 17 - Attributes. Represents the RANK.")]
        public string PMAttributes { get; set; }

        [Description("Physically labeled bank where the memory is located.")]
        public string PMBankLabel { get; set; }

        [Description("Total capacity of the physical memory—in bytes.")]
        public string PMCapacity { get; set; }

        [Description("The configured clock speed of the memory device, in megahertz (MHz), or 0, if the speed is unknown.")]
        public string PMConfiguredClockSpeed { get; set; }

        [Description("Label of the socket or circuit board that holds the memory.")]
        public string PMDeviceLocator { get; set; }

        [Description("Implementation form factor for the chip.")]
        public string PMFormFactor { get; set; }

        [Description("Name of the organization responsible for producing the physical element.")]
        public string PMManufacturer { get; set; }

        [Description("Type of physical memory.")]
        public string PMMemoryType { get; set; }

        [Description("Label for the object.")]
        public string PMName { get; set; }

        [Description("Part number assigned by the organization responsible for producing or manufacturing the physical element.")]
        public string PMPartNumber { get; set; }

        [Description("Manufacturer-allocated number to identify the physical element.")]
        public string PMSerialNumber { get; set; }

        [Description("Speed of the physical memory—in nanoseconds.")]
        public string PMSpeed { get; set; }

        [Description("Current status of the object.")]
        public string PMStatus { get; set; }

        [Description("Type of physical memory represented.")]
        public string PMTypeDetail { get; set; }

        [Description("Version of the physical element.")]
        public string PMVersion { get; set; }
    }
}