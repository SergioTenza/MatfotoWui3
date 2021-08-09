using MatfotoWui3.Core.Contracts.Services;
using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Core.Services
{
    public class PrinterStatusService : IPrinterStatusService
    {
        private PrinterStatus _printerStatus;
        private string _printerName { get; set; }

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
            _printerStatus.PrinterFirmware = GetFirmware(_printerName);
            _printerStatus.PrinterPortNumber = Convert.ToInt32(GetPortNumber(_printerName));
            _printerStatus.PrinterTotalLifePrints = Convert.ToInt32(GetTotalPrints(_printerName));
            _printerStatus.PrinterLeftMedia = Convert.ToInt32(GetLeftPrints(_printerName));

            return CitizenPrinterStatus;
        }

        private string GetFirmware(string printerName)
        {
            try
            {
                return "test";
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
            try
            {
                return "test3";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string GetPortNumber(string printerName)
        {
            try
            {
                return "4";
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
