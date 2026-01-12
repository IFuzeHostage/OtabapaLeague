using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Data.Settings
{
    public interface ISettingsLoader
    {
        UniTask<T> LoadSettings<T>(string path) where T : ISettingsData;
    }
}