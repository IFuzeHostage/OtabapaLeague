using Cysharp.Threading.Tasks;
using OtabapaLeague.Scripts.Data;
using UnityEngine;

namespace OtabapaLeague.Domain.SettingsLoader
{
    public class SettingsLoader : ISettingsLoader
    {
        public UniTask<T> LoadSettings<T>(string path) where T : ISettingsData
        {
            var settings = Resources.Load<SettingsScriptableObject>(path);
            var settingsData = (T)settings.GetSettingsData();
            return UniTask.FromResult(settingsData);
        }
    }
}