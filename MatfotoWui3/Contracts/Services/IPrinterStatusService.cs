
using MatfotoWui3.Core.Models;

namespace MatfotoWui3.Contracts.Services
{
    public interface IPrinterStatusService
    {
        PrinterStatus GetPrinterStatus(string printerName);
    }
}