using UnityEngine;

namespace OtabapaLeague.Data
{
    public abstract class SettingsScriptableObject : ScriptableObject
    {
        public abstract ISettingsData GetSettingsData();
    }
}