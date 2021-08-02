using System.Threading.Tasks;

namespace MatfotoWui3.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
