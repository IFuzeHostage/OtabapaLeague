using Cysharp.Threading.Tasks;
using OtabapaLeague.Domain.Systems.DataSerializer;
using UnityEngine;

namespace OtabapaLeague.Data.Systems
{
    public class PlayerPrefsDataSaver : IDataSaver
    {
        private readonly IDataSerializer _dataSerializer;
        
        public PlayerPrefsDataSaver(IDataSerializer dataSerializer)
        {
            _dataSerializer = dataSerializer;
        }
        
        public UniTask SaveData(string key, object toSave)
        {
            var serializedData = _dataSerializer.Serialize(toSave);
            PlayerPrefs.SetString(key, serializedData);
            return UniTask.CompletedTask;
        }

        public UniTask<T> LoadData<T>(string key)
        {
            var serializedData = PlayerPrefs.GetString(key);
            var deserializedData = _dataSerializer.Deserialize<T>(serializedData);
            return UniTask.FromResult(deserializedData);
        }
    }
}