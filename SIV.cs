// Copyright (c) 2018 Jason Harvey
// Created by Jason Harvey AKA CommandoRambo.
// MIT License
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.Remoting.Channels;
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
            SoundDevice();
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
        private static string GetValue(ManagementObject mo, string propName)
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
        private static string GetOutput(string input)
        {
            if (input.StartsWith("Error"))
            {
                input = String.Empty;
            }

            string output = String.Empty;

            return input != String.Empty ? input : nullValue;
        }

        // Convert date to readable format.
        private static string ConvertDateTime(string dateTime)
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

        // Bitmask decode product suite..
        private static string DecodeProductSuite(int suiteValue)
        {
            string outputSuite = String.Empty;

            if ((suiteValue & 16384) == 16384)
            {
                outputSuite += dProductSuite[8192] + ", ";
            }

            if ((suiteValue & 8192) == 8192)
            {
                outputSuite += dProductSuite[8192] + ", ";
            }

            if ((suiteValue & 1024) == 1024)
            {
                outputSuite += dProductSuite[1024] + ", ";
            }

            if ((suiteValue & 512) == 512)
            {
                outputSuite += dProductSuite[512] + ", ";
            }

            if ((suiteValue & 256) == 256)
            {
                outputSuite += dProductSuite[256] + ", ";
            }

            if ((suiteValue & 128) == 128)
            {
                outputSuite += dProductSuite[128] + ", ";
            }

            if ((suiteValue & 64) == 64)
            {
                outputSuite += dProductSuite[64] + ", ";
            }

            if ((suiteValue & 32) == 32)
            {
                outputSuite += dProductSuite[32] + ", ";
            }

            if ((suiteValue & 16) == 16)
            {
                outputSuite += dProductSuite[16] + ", ";
            }

            if ((suiteValue & 8) == 8)
            {
                outputSuite += dProductSuite[8] + ", ";
            }

            if ((suiteValue & 4) == 4)
            {
                outputSuite += dProductSuite[4] + ", ";
            }

            if ((suiteValue & 2) == 2)
            {
                outputSuite += dProductSuite[2] + ", ";
            }

            if ((suiteValue & 1) == 1)
            {
                outputSuite += dProductSuite[1] + ", ";
            }

            // Remove the last 2 characters if they are "; ".
            if (outputSuite.EndsWith(", "))
            {
                outputSuite = outputSuite.Remove(outputSuite.Length - 2, 2) + ".";
            }

            return outputSuite;
        }

        // Bitmask decode suite mask.
        private static string DecodeSuitemask(int suiteValue)
        {
            string outputSuite = string.Empty;

            if ((suiteValue & 1024) == 1024)
            {
                outputSuite += dSuiteMask[1024] + ", ";
            }

            if ((suiteValue & 512) == 512)
            {
                outputSuite += dSuiteMask[512] + ", ";
            }

            if ((suiteValue & 256) == 256)
            {
                outputSuite += dSuiteMask[256] + ", ";
            }

            if ((suiteValue & 128) == 128)
            {
                outputSuite += dSuiteMask[128] + ", ";
            }

            if ((suiteValue & 64) == 64)
            {
                outputSuite += dSuiteMask[64] + ", ";
            }

            if ((suiteValue & 32) == 32)
            {
                outputSuite += dSuiteMask[32] + ", ";
            }

            if ((suiteValue & 16) == 16)
            {
                outputSuite += dSuiteMask[16] + ", ";
            }

            if ((suiteValue & 8) == 8)
            {
                outputSuite += dSuiteMask[8] + ", ";
            }

            if ((suiteValue & 4) == 4)
            {
                outputSuite += dSuiteMask[4] + ", ";
            }

            if ((suiteValue & 2) == 2)
            {
                outputSuite += dSuiteMask[2] + ", ";
            }

            if ((suiteValue & 1) == 1)
            {
                outputSuite += dSuiteMask[1] + ", ";
            }

            // Remove the last 2 characters if they are "; ".
            if (outputSuite.EndsWith(", "))
            {
                outputSuite = outputSuite.Remove(outputSuite.Length - 2, 2) + ".";
            }

            return outputSuite;
        }

        // Bitmask decode Type detail.
        private static string DecodeTypeDetail(int typeValue)
        {
            string outputValue = String.Empty;

            if ((typeValue & 4096) == 4096)
            {
                outputValue += dSuiteMask[4096] + ", ";
            }

            if ((typeValue & 2048) == 2048)
            {
                outputValue += dSuiteMask[2048] + ", ";
            }

            if ((typeValue & 1024) == 1024)
            {
                outputValue += dSuiteMask[1024] + ", ";
            }

            if ((typeValue & 512) == 512)
            {
                outputValue += dSuiteMask[512] + ", ";
            }

            if ((typeValue & 256) == 256)
            {
                outputValue += dSuiteMask[256] + ", ";
            }

            if ((typeValue & 128) == 128)
            {
                outputValue += dSuiteMask[128] + ", ";
            }

            if ((typeValue & 64) == 64)
            {
                outputValue += dSuiteMask[64] + ", ";
            }

            if ((typeValue & 32) == 32)
            {
                outputValue += dSuiteMask[32] + ", ";
            }

            if ((typeValue & 16) == 16)
            {
                outputValue += dSuiteMask[16] + ", ";
            }

            if ((typeValue & 8) == 8)
            {
                outputValue += dSuiteMask[8] + ", ";
            }

            if ((typeValue & 4) == 4)
            {
                outputValue += dSuiteMask[4] + ", ";
            }

            if ((typeValue & 2) == 2)
            {
                outputValue += dSuiteMask[2] + ", ";
            }

            if ((typeValue & 1) == 1)
            {
                outputValue += dSuiteMask[1] + ", ";
            }

            // Remove the last 2 characters if they are "; ".
            if (outputValue.EndsWith(", "))
            {
                outputValue = outputValue.Remove(outputValue.Length - 2, 2) + ".";
            }

            return outputValue;
        }

        // Convert Bytes to a readable format.
        private static string ReadableSize(long inputSize, int decimalPlace = 0)
        {
            // The 'inputSize' is in bytes.

            string outputSize = String.Empty;

            long lBytes = 1024;
            long lKB = lBytes * 1024;
            long lMB = lKB * 1024;
            long lGB = lMB * 1024;
            long lTB = lGB * 1024;

            var tb = Math.Round((double)inputSize / lTB, decimalPlace);
            var gb = Math.Round((double)inputSize / lGB, decimalPlace);
            var mb = Math.Round((double)inputSize / lMB, decimalPlace);
            var kb = Math.Round((double)inputSize / lKB, decimalPlace);

            if (tb > 1)
            {
                outputSize = string.Format("{0}" + sizeSuffix[0], tb);
            }
            else if (gb > 1)
            {
                outputSize = string.Format("{0}" + sizeSuffix[1], gb);
            }
            else if (mb > 1)
            {
                outputSize = string.Format("{0}" + sizeSuffix[2], mb);
            }
            else if (kb > 1)
            {
                outputSize = string.Format("{0}" + sizeSuffix[3], kb);
            }
            else
            {
                outputSize = string.Format("{0}" + sizeSuffix[4], inputSize);
            }

            return outputSize;
        }
        #endregion
    }
}
