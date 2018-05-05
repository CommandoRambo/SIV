using System.Management;

namespace SIV
{
    public partial class SystemInfomation
    {
        private void Audio()
        {
            sqlQuery = new SelectQuery("SELECT * FROM Win32_OperatingSystem");

            moSearcherInfo = new ManagementObjectSearcher(sqlQuery);

            foreach (ManagementObject mo in moSearcherInfo.Get())
            {

            }
        }


    }
}