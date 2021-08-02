using System.Threading.Tasks;

namespace MatfotoWui3.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
