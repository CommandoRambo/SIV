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
        private void Processor()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_Processor");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {
                // Architecture.
                PArchitecture = GetOutput(dProcessorArchitecture[Convert.ToInt16(GetValue(mo, "Architecture"))]);

                // Asset Tag.
                PAssetTag = GetOutput(GetValue(mo, "AssetTag"));

                // Availability.
                PAvailability = GetOutput(dProcessorAvailability[Convert.ToInt16(GetValue(mo, "Availability"))]);

                // Characteristics.
                PCharacteristics = GetOutput(GetValue(mo, "Characteristics"));

                // CPU Status.
                PCPUStatus = GetOutput(dCPUStatus[Convert.ToInt32(GetValue(mo, "CpuStatus"))]);

                // Current Clock Speed.
                PCurrentClockSpeed = GetOutput(GetValue(mo, "CurrentClockSpeed"));

                // Current Voltage.
                PCurrentVoltage = GetOutput(GetValue(mo, "CurrentVoltage"));

                // Description.
                PDescription = GetOutput(GetValue(mo, "Description"));

                // Device ID.
                PDeviceID = GetOutput(GetValue(mo, "DeviceID"));

                // Family.
                // PFamily = GetOutput(dProcessorFamily[Convert.ToInt16(GetValue(mo, "Family"))]);

                // Level.
                PLevel = GetOutput(GetValue(mo, "Level"));

                // Load Percentage.
                PLoadPercentage = GetOutput(GetValue(mo, "LoadPercentage"));

                // Manufacturer.
                PManufacturer = GetOutput(GetValue(mo, "Manufacturer"));

                // Max Clock Speed.
                PMaxClockSpeed = GetOutput(GetValue(mo, "MaxClockSpeed"));

                // Name.
                PName = GetOutput(GetValue(mo, "Name"));

                // Number Of Cores.
                PNumberOfCores = GetOutput(GetValue(mo, "NumberOfCores"));

                // Number Of Enabled Cores.
                PNumberOfEnabledCores = GetOutput(GetValue(mo, "NumberOfEnabledCore"));

                // Number Of Logical Processors.
                PNumberOfLogicalProcessors = GetOutput(GetValue(mo, "NumberOfLogicalProcessors"));

                // Part Number.
                PPartNumber = GetOutput(GetValue(mo, "PartNumber"));

                // Processor ID.
                PProcessorID = GetOutput(GetValue(mo, "ProcessorId"));

                // Processor Type.
                PProcessorType = GetOutput(dProductTypes[Convert.ToInt16(GetValue(mo, "ProcessorType"))]);

                // Revision.
                PRevision = GetOutput(GetValue(mo, "Revision"));

                // Role.
                PRole = GetOutput(GetValue(mo, "Role"));

                // Serial Number.
                PSerialNumber = GetOutput(GetValue(mo, "SerialNumber"));

                // Socket Designation.
                PSocketDesignation = GetOutput(GetValue(mo, "SocketDesignation"));

                // Status.
                PStatus = GetOutput(GetValue(mo, "Status"));

                // Status Info.
                PStatusInfo = GetOutput(dProcessorStatusInfo[Convert.ToInt16(GetValue(mo, "StatusInfo"))]);

                // Thread Count.
                PThreadCount = GetOutput(GetValue(mo, "ThreadCount"));

                // Uniquue ID.
                PUniqueID = GetOutput(GetValue(mo, "UniqueId"));

                // Upgrade Method.
                // PUpgradeMethod = GetOutput(dUpgradeMethod[Convert.ToInt16(GetValue(mo, "UpgradeMethod"))]);

                // Version.
                PVersion = GetOutput(GetValue(mo, "Version"));

                // Voltage Caps.
                PVoltageCaps = GetOutput(GetValue(mo, "VoltageCaps"));
            }
        }

        [Description("Processor architecture used by the platform.")]
        public string PArchitecture { get; set; }

        [Description("Represents the asset tag of this processor.")]
        public string PAssetTag { get; set; }

        [Description("Availability and status of the device.")]
        public string PAvailability { get; set; }

        [Description("Defines which functions the processor supports.")]
        public string PCharacteristics { get; set; }

        [Description("Current status of the processor. Status changes indicate processor usage, but not the physical condition of the processor.")]
        public string PCPUStatus { get; set; }

        [Description("Current speed of the processor, in MHz.")]
        public string PCurrentClockSpeed { get; set; }

        [Description("Voltage of the processor.")]
        public string PCurrentVoltage { get; set; }

        [Description("Description of the object.")]
        public string PDescription { get; set; }

        [Description("Unique identifier of a processor on the system.")]
        public string PDeviceID { get; set; }

        [Description("Processor family type.")]
        public string PFamily { get; set; }

        [Description("Definition of the processor type. The value depends on the architecture of the processor.")]
        public string PLevel { get; set; }

        [Description("Load capacity of each processor, averaged to the last second. Processor loading refers to the total computing burden for each processor at one time.")]
        public string PLoadPercentage { get; set; }

        [Description("Name of the processor manufacturer.")]
        public string PManufacturer { get; set; }

        [Description("Maximum speed of the processor, in MHz.")]
        public string PMaxClockSpeed { get; set; }

        [Description("Label by which the object is known.")]
        public string PName { get; set; }

        [Description("Number of cores for the current instance of the processor. A core is a physical processor on the integrated circuit.")]
        public string PNumberOfCores { get; set; }

        [Description("The number of enabled cores per processor socket.")]
        public string PNumberOfEnabledCores { get; set; }

        [Description("Number of logical processors for the current instance of the processor.")]
        public string PNumberOfLogicalProcessors { get; set; }

        [Description("he part number of this processor as set by the manufacturer.")]
        public string PPartNumber { get; set; }

        [Description("Processor information that describes the processor features.")]
        public string PProcessorID { get; set; }

        [Description("Primary function of the processor.")]
        public string PProcessorType { get; set; }

        [Description("System revision level that depends on the architecture.")]
        public string PRevision { get; set; }

        [Description("Role of the processor.")]
        public string PRole { get; set; }

        [Description("The serial number of this processor This value is set by the manufacturer and normally not changeable.")]
        public string PSerialNumber { get; set; }

        [Description("Type of chip socket used on the circuit.")]
        public string PSocketDesignation { get; set; }

        [Description("Current status of an object.")]
        public string PStatus { get; set; }

        [Description("State of the logical device.")]
        public string PStatusInfo { get; set; }

        [Description("The number of threads per processor socket.")]
        public string PThreadCount { get; set; }

        [Description("Globally unique identifier for the processor. This identifier may only be unique within a processor family.")]
        public string PUniqueID { get; set; }

        [Description("CPU socket information, including the method by which this processor can be upgraded,")]
        public string PUpgradeMethod { get; set; }

        [Description("Processor revision number that depends on the architecture.")]
        public string PVersion { get; set; }

        [Description("Voltage capabilities of the processor.")]
        public string PVoltageCaps { get; set; }
    }
}