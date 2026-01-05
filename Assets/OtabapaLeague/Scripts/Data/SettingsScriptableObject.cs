using UnityEngine;

namespace OtabapaLeague.Scripts.Data
{
    public abstract class SettingsScriptableObject : ScriptableObject
    {
        public abstract ISettingsData GetSettingsData();
    }
}