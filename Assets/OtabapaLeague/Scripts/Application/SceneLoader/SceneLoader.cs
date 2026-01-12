using Cysharp.Threading.Tasks;
using OtabapaLeague.Data.SceneLoader;
using OtabapaLeague.Data.Settings;
using UnityEngine.SceneManagement;

namespace OtabapaLeague.Application.SceneLoader
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