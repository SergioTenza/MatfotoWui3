using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    internal static class GetPrinterPort
    {
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]


        private static extern bool OpenPrinter(string src, ref IntPtr hPrinter, int pd);
        [DllImport("winspool.Drv", EntryPoint = "EnumJobsW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]


        private static extern int EnumJobs(int hPrinter, int FirstJob, int NoJobs, int Level, ref IntPtr pJob, int cdBuf, ref int pcbNeeded, ref int pcReturned);
        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]


        private static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool GetPrinter(IntPtr hPrinter, int dwLevel, IntPtr pPrinter, int cbBuf, ref int pcbNeeded);



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public partial struct PRINTER_INFO_5
        {
            public IntPtr pPrinterName;
            public IntPtr pPortName;
            public int Attributes;
            public int DeviceNotSelectedTimeout;
            public int TransmissionRetryTimeout;
        }

        private const int PRINTER_ATTRIBUTE_DEFAULT = 0x4;
        private const int PRINTER_ATTRIBUTE_ENABLE_BIDI = 0x800;
        private const int PRINTER_ATTRIBUTE_WORK_OFFLINE = 0x400;

        public static string GetPortName(ref string strPrinterDeviceName)
        {
            string? GetPortNameRet = default;
            int lngPrinterInfo5Level;
            var lngPrinterInfo5Needed = default(int);
            var temp = default(int);
            lngPrinterInfo5Level = 5;

            // 
            IntPtr hPrinter = IntPtr.Zero;
            if (!OpenPrinter(strPrinterDeviceName, ref hPrinter, (int)IntPtr.Zero))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            var pPrinterInfo = IntPtr.Zero;
            

            try
            {

                // 
                GetPrinter(hPrinter, lngPrinterInfo5Level, IntPtr.Zero, 0, ref lngPrinterInfo5Needed);
                if (lngPrinterInfo5Needed <= 0)
                {
                    throw new Exception("error!");
                }
                // 
                pPrinterInfo = Marshal.AllocHGlobal(lngPrinterInfo5Needed);

                // 
                if (!GetPrinter(hPrinter, lngPrinterInfo5Level, pPrinterInfo, lngPrinterInfo5Needed, ref temp))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                // 
#pragma warning disable CS8605 // Conversión unboxing a un valor posiblemente NULL.
                PRINTER_INFO_5 printerInfo = (PRINTER_INFO_5)Marshal.PtrToStructure(pPrinterInfo, typeof(PRINTER_INFO_5));
#pragma warning restore CS8605 // Conversión unboxing a un valor posiblemente NULL.

                if (Microsoft.VisualBasic.CompilerServices.Conversions.ToBoolean(printerInfo.Attributes & PRINTER_ATTRIBUTE_ENABLE_BIDI & Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger((printerInfo.Attributes & PRINTER_ATTRIBUTE_WORK_OFFLINE) == 0)))
                {
                    GetPortNameRet = Marshal.PtrToStringUni(printerInfo.pPortName);
                }
                else
                {
                    GetPortNameRet = "";
                }
            }
            finally
            {
                // 
                ClosePrinter(hPrinter);
                Marshal.FreeHGlobal(pPrinterInfo);
            }

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return GetPortNameRet;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }
    }
}
