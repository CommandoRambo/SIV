// Copyright © 2018 JRV Solutions.
// Created by Jason Harvey AKA CommandoRambo.
using System;
using System.ComponentModel;
using System.Management;
using System.Reflection;

namespace SIV
{
    public partial class SIV
    {
        #region METHODS
        private void Battery()
        {
            try
            {
                sqlQuery = new SelectQuery("SELECT * FROM Win32_Battery");

                moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

                foreach (ManagementObject mo in moSearcherInfo.Get())
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                sqlQuery = new SelectQuery(@"SELECT * FROM CIM_Battery WHERE Caption='Portable Battery'");

                moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

                foreach (ManagementObject mo in moSearcherInfo.Get())
                {
                    // Chemistry.
                    int temp = Convert.ToUInt16(GetValue(mo, "Chemistry"));
                    BatteryChemistry = dBatteryChemistry[temp];
                    // Manufacture Date.
                    BatteryManufactureDate = GetValue(mo, "ManufactureDate");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        #endregion

        #region PROPERTIES
        [Description("The type of chemistry used in the battery.")]
        public string BatteryChemistry { get; set; }
        [Description("The manufacture date of the battery.")]
        public string BatteryManufactureDate { get; set; }


        #endregion
    }
}