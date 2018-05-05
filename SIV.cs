// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SIV
{
    public partial class SystemInfomation
    {
        #region CONSTRUCTORS

        public SystemInfomation()
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
        // Get the value from the management object.
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

        // Get output string.
        private string GetOutput(string input)
        {
            string output = String.Empty;

            return input != String.Empty ? input : nullValue;
        }

        // Convert date to readable format.
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

        // Get the DigitalProductId in bytes.
        public static byte[] GetProductKey(string key)
        {
            byte[] digitalProductId = null;
            RegistryKey localKey = null;

            if (Environment.Is64BitOperatingSystem)
            {
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            }

            digitalProductId = localKey.OpenSubKey(SUBKEY).GetValue(key) as byte[];
            localKey.Close();

            return digitalProductId;
        }

        // Decodes the DiditalProductId in to a readable string.
        public static string Decode(byte[] digitalProductId)
        {
            const int keyStartIndex = 52;
            const int keyEndIndex = keyStartIndex + 15;
            char[] digits = new char[]
            {
                'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R',
                'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
            };
            const int decodeLength = 29;
            const int decodeStringLength = 15;
            char[] decodedChars = new char[decodeLength];
            ArrayList hexPid = new ArrayList();
            for (int i = keyStartIndex; i <= keyEndIndex; i++)
            {
                hexPid.Add(digitalProductId[i]);
            }
            for (int i = decodeLength - 1; i >= 0; i--)
            {
                if ((i + 1) % 6 == 0)
                {
                    decodedChars[i] = '-';
                }
                else
                {
                    int digitMapIndex = 0;
                    for (int j = decodeStringLength - 1; j >= 0; j--)
                    {
                        int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                        hexPid[j] = (byte)(byteValue / 24);
                        digitMapIndex = byteValue % 24;
                        decodedChars[i] = digits[digitMapIndex];
                    }
                }
            }
            return new string(decodedChars);
        }
        #endregion
    }
}
