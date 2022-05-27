using System.Threading.Tasks;

namespace AlquitaTuCarro_GUI.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
