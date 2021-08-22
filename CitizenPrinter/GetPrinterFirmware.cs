using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    internal static class GetPrinterFirmware
    {
        public static string GetVersionInformation(int portNumber)
        {
            string s = new string(Conversions.ToChar(""), 255);
            int l = 0;
            if (WRAPPER.Printer != null)
            {
                try
                {
                    //l = WRAPPER.Printer.GetFirmwVersion(portNumber, ref s);
                    l = Cx02Statx64.GetFirmwVersion(portNumber, s);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            if (l >= 0)
                return l.ToString();
            else
                return "ERROR!";
        }
    }
}
