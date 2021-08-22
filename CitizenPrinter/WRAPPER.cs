using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{    
    public static class WRAPPER
    {
        public static dynamic? Printer;
        private static bool Is64 = IntPtr.Size == 8;        

        public static bool SetWorkingPrinter(string printerName)
        {
            string nameToUpper = printerName.ToUpper();
            bool result = false;
            switch (nameToUpper)
            {
                case "CITIZEN CX-02":
                    if (Is64)
                    {
                        Printer = new Cx02Statx64();
                    }
                    else
                    {
                        Printer = new Cx02Stat();
                    }
                    result = true;
                    break;
                case "CITIZEN CX-02W":
                    if (Is64)
                    {
                        //Printer = new Cx02WStatx64();
                        Printer = new Cx02WStat();
                    }
                    else
                    {
                        Printer = new Cx02WStat();
                    }
                    result = true;
                    break;
                case "CY":
                    if (Is64)
                    {
                        Printer = new CyStatx64();
                    }
                    else
                    {
                        Printer = new CyStat();
                    }
                    result = true;
                    break;
                    
                default:
                    break;
            }
            return result;
        }

        public static string GetPrinterPortName(string printerName)
        {
            var response = String.Empty;
            try
            {
                response = GetPrinterPort.GetPortName(ref printerName);
            }
            catch (Exception)
            {
                throw;
                
            }            
            return response;
        }

        public static int GetPortNo(string portName)
        {
            var response = 0;
            switch (portName)
            {
                case "CITIZEN CX-02":
                    if (Is64)
                    {
                        Printer = new Cx02Statx64();
                    }
                    else
                    {
                        Printer = new Cx02Stat();
                    }
                    
                    break;
                case "CITIZEN CX-02W":
                    if (Is64)
                    {
                        //Printer = new Cx02WStatx64();
                        response =  Cx02WStatx64.PortInitialize(portName);
                        
                    }
                    else
                    {
                        Printer = new Cx02WStat();
                    }
                    
                    break;
                case "CY":
                    if (Is64)
                    {
                        Printer = new CyStatx64();
                    }
                    else
                    {
                        Printer = new CyStat();
                    }
                    
                    break;

                default:
                    break;
            }

            return response;
            //var response = 0;
            //try
            //{
            //    response = GetPortNumber.GetPort(ref portName);
            //}
            //catch (Exception)
            //{
            //    response = -1;

            //}
            //return response;
        }

        public static string GetFirmware(int portNumber)
        {

            var response = String.Empty;

            if (portNumber >= 0)
            {
                try
                {
                    response = GetPrinterFirmware.GetVersionInformation(portNumber);
                }
                catch (Exception ex)
                {
                    response = $"ERROR \n {ex.Message}";

                }
            }

            response = $"PUERTO ERRONEO: {portNumber}";
            
            return response;
        }
    }
}
