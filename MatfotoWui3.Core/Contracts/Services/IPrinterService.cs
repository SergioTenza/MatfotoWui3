using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Core.Contracts.Services
{
    public interface IPrinterService
    {
        Task<IEnumerable<Printer>> GetAllPrintersAsync();
    }
}
