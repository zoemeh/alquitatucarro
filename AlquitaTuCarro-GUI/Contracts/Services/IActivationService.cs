using System.Threading.Tasks;

namespace AlquitaTuCarro_GUI.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
