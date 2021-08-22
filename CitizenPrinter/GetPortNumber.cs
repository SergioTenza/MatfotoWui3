using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    internal static class GetPortNumber
    {
        public static int GetPort(ref string portName)
        {
            var response = 0;

            if (WRAPPER.Printer != null)
            {
                try
                {
                    response = WRAPPER.Printer.PortInitialize(ref portName);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            if (response >= 0)
                return response;
            else
                return -1;
        }
    }
}
