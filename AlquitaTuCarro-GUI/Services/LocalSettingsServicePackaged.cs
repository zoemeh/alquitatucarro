using System.Threading.Tasks;

using AlquitaTuCarro_GUI.Contracts.Services;
using AlquitaTuCarro_GUI.Core.Helpers;

using Windows.Storage;

namespace AlquitaTuCarro_GUI.Services
{
    public class LocalSettingsServicePackaged : ILocalSettingsService
    {
        public async Task<T> ReadSettingAsync<T>(string key)
        {
            object obj = null;

            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out obj))
            {
                return await Json.ToObjectAsync<T>((string)obj);
            }

            return default;
        }

        public async Task SaveSettingAsync<T>(string key, T value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = await Json.StringifyAsync(value);
        }
    }
}
