using Cysharp.Threading.Tasks;
using OtabapaLeague.Domain.SettingsLoader;
using OtabapaLeague.Scripts.Data.SceneLoader;
using UnityEngine.SceneManagement;

namespace OtabapaLeague.Domain.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private ISettingsLoader _settingsLoader;

        private SceneLoaderSettings _settings;
        
        public SceneLoader(ISettingsLoader settingsLoader)
        {
            _settingsLoader = settingsLoader;
        }
        
        public async UniTask Init()
        {
            _settings = await _settingsLoader.LoadSettings<SceneLoaderSettings>(SceneLoaderSettingsEntry.PATH);
        }

        public async UniTask LoadUIScene()
        {
            await SceneManager.LoadSceneAsync(_settings.UISceneName, LoadSceneMode.Additive);
        }

        public async UniTask LoadMainScene()
        {
            await SceneManager.LoadSceneAsync(_settings.MainSceneName, LoadSceneMode.Additive);
        }
    }
}