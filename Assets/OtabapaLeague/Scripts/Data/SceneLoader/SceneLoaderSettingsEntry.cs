using UnityEngine;

namespace OtabapaLeague.Scripts.Data.SceneLoader
{
    [CreateAssetMenu(menuName = "OtabapaLeague/Data/SceneLoader", fileName = PATH)]
    public class SceneLoaderSettingsEntry : SettingsScriptableObject
    {
        public const string PATH = "a_settings_sceneLoader";
        
        [SerializeField]
        private string uiSceneName;
        [SerializeField]
        private string mainSceneName;
        
        public override ISettingsData GetSettingsData()
        {
            return new SceneLoaderSettings(uiSceneName, mainSceneName);
        }
    }
}