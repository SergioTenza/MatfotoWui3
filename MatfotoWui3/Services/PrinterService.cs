
using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Services
{
    public class PrinterService : IPrinterService
    {
        private List<Printer> _allPrinters;
        private List<string> _allPrinterNames;

        public PrinterService()
        {

        }

        public async Task<IEnumerable<Printer>> GetAllPrintersAsync()
        {
            if (_allPrinterNames == null)
            {
                _allPrinterNames = new List<string>(AllPrinterNames());
            }

            await Task.CompletedTask;
            
            if (_allPrinters == null)
            {
                _allPrinters = new List<Printer>(AllPrinters());
            }

            await Task.CompletedTask;
            return _allPrinters;
        }

        private static IEnumerable<Printer> AllPrinters()
        {
            AllPrinterNames();
            return new List<Printer>()
            {
                new Printer()
                {

                }
            };
        }

        private static IEnumerable<string> AllPrinterNames()
        {
            var printerNames = new List<string>();
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                printerNames.Add(printname);
            }
            return printerNames;
        }

    }
}
