﻿using System.Management;

namespace SIV
{
    public partial class SIV
    {
        private void Memory()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_OperatingSystem");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {

            }
        }
    }
}