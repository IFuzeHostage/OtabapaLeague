using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Data;

namespace OtabapaLeague.Domain.SettingsLoader
{
    public interface ISettingsLoader
    {
        UniTask<T> LoadSettings<T>(string path) where T : ISettingsData;
    }
}