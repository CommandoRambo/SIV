using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SIV
{
    public partial class SIV
    {
        #region CONSTRUCTORS

        public SIV()
        {
            SetupDictionary();
            Audio();
            BaseBoard();
            Battery();
            Bios();
            Graphics();
            Memory();
            Network();
            OperatingSystem();
            Optical();
            Processor();
            Storage();
        }
        #endregion

        #region METHODS
        private string GetValue(ManagementObject mo, string propName)
        {
            string value;

            try
            {
                value = mo[propName].ToString();
            }
            catch (Exception ex)
            {
                value = "Error: " + ex.Message;
            }

            return value;
        }

        private string ConvertDateTime(string dateTime)
        {
            string[] dateArray = dateTime.Split(stopSeperator, StringSplitOptions.RemoveEmptyEntries);

            string date = dateArray[0].Substring(0, 8);
            string time = dateArray[0].Substring(8, dateArray[0].Length - 8);

            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);

            string hours = time.Substring(0, 2);
            string minutes = time.Substring(2, 2);
            string seconds = time.Substring(4, 2);

            string returnDateTime = string.Concat(day, "/", month, "/", year, " - ", hours, ":", minutes, ":", seconds);

            return returnDateTime;
        }
        #endregion
    }
}
