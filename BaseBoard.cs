// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License

using System.ComponentModel;
using System.Management;

namespace SIV
{
    public partial class SystemInfomation
    {
        private void BaseBoard()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_BaseBoard");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Manufacturer.
                BBManufacturer = GetOutput(GetValue(mo, "Manufacturer"));

                // Model.
                BBModel = GetOutput(GetValue(mo, "Model"));

                // Name.
                BBName = GetOutput(GetValue(mo, "Name"));

                // Part Number.
                BBPartNumber = GetOutput(GetValue(mo, "PartNumber"));

                // Product.
                BBProduct = GetOutput(GetValue(mo, "Product"));

                // Replaceable.
                BBReplaceable = GetOutput(GetValue(mo, "Replaceable"));

                // Serial Number.
                BBSerialNumber = GetOutput(GetValue(mo, "SerialNumber"));

                // Status.
                BBStatus = GetOutput(GetValue(mo, "Status"));

                // Version.
                BBVersion = GetOutput(GetValue(mo, "Version"));

                // Config Options.
                //foreach (var option in COLLECTION)
                //{
                    //BBConfigOptions;
                //}
            }
        }

        [Description("Name of the organization responsible for producing the physical element.")]
        public string BBManufacturer { get; set; }

        [Description("Name by which the physical element is known.")]
        public string BBModel { get; set; }

        [Description("Label by which the object is known.")]
        public string BBName { get; set; }

        [Description("Part number assigned by the organization responsible for producing or manufacturing the physical element.")]
        public string BBPartNumber { get; set; }

        [Description("Baseboard part number defined by the manufacturer.")]
        public string BBProduct { get; set; }

        [Description("If TRUE, a package is replaceable.")]
        public string BBReplaceable { get; set; }

        [Description("Manufacturer-allocated number used to identify the physical element.")]
        public string BBSerialNumber { get; set; }

        [Description("Current status of the object.")]
        public string BBStatus { get; set; }

        [Description("Version of the physical element.")]
        public string BBVersion { get; set; }

        [Description("Array that represents the configuration of the jumpers and switches located on the baseboard.")]
        public string[] BBConfigOptions { get; set; }



    }
}