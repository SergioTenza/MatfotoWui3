using System.Collections.Generic;
using System.Threading.Tasks;

using MatfotoWui3.Core.Models;

namespace MatfotoWui3.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
    }
}
