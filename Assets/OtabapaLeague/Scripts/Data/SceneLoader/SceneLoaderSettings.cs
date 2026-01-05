namespace OtabapaLeague.Scripts.Data.SceneLoader
{
    public class SceneLoaderSettings : ISettingsData
    {
        public readonly string UISceneName;
        public readonly string MainSceneName;

        public SceneLoaderSettings(string uiSceneName, string mainSceneName)
        {
            UISceneName = uiSceneName;
            MainSceneName = mainSceneName;
        }
    }
}