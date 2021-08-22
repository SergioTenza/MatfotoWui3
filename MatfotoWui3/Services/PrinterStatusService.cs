using CitizenPrinter;
using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Services
{
    public class PrinterStatusService : IPrinterStatusService
    {
        private PrinterStatus _printerStatus;
        private string _printerName { get; set; }
        private string _portName { get; set; }
        private int _portNumber { get; set; }

        PrinterStatus CitizenPrinterStatus
        {
            get { return _printerStatus; }
            set { _printerStatus = GetPrinterStatus(_printerName); }
        }

        public PrinterStatusService()
        {
            
        }

        public PrinterStatus GetPrinterStatus(string printerName)
        {
            _printerStatus = new PrinterStatus();
            _printerName = printerName;
            _printerStatus.PrinterName = _printerName;
            _printerStatus.PrinterState = GetStatus(_printerName);
            _printerStatus.PrinterPortName = GetPortName(_printerName);
            int number;
            bool success = Int32.TryParse(GetPortNumber(_portName), out number);
            if (success)
            {
                _printerStatus.PrinterPortNumber = number;
            }
            else
            {
                _printerStatus.PrinterPortNumber = -1;
            }
            
            _printerStatus.PrinterFirmware = GetFirmware(_portNumber);            
            _printerStatus.PrinterTotalLifePrints = Convert.ToInt32(GetTotalPrints(_printerName));
            _printerStatus.PrinterLeftMedia = Convert.ToInt32(GetLeftPrints(_printerName));

            return CitizenPrinterStatus;
        }

        private string GetFirmware(int portNumber)
        {
            var response = "ERROR";
            try
            {   
                if (WRAPPER.Printer != null)
                {
                    response = WRAPPER.GetFirmware(portNumber);
                }
                return response;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string GetLeftPrints(string printerName)
        {
            try
            {
                return "2";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string GetPortName(string printerName)
        {
            var response = "ERROR"; 
            try
            {
                WRAPPER.SetWorkingPrinter(printerName);
                if (WRAPPER.Printer != null)
                {
                    response =  WRAPPER.GetPrinterPortName(printerName);
                }
                _portName = response;
                return response;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string GetPortNumber(string portName)
        {
            var response = "ERROR";
            var port = 0;
            try
            {
                if (WRAPPER.Printer != null)
                {
                    port = WRAPPER.GetPortNo(portName);
                    response = port.ToString();
                }
                _portNumber = port;
                return response;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string GetStatus(string printerName)
        {
            try
            {
                return "test5";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string GetTotalPrints(string printerName)
        {
            try
            {
                return "6";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
