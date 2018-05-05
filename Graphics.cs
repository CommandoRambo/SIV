// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License
using System.Management;

namespace SIV
{
    public partial class SystemInfomation
    {
        private void Graphics()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_OperatingSystem");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {

            }
        }
    }
}