using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Data.Systems
{
    public interface IDataSaver
    {
        UniTask SaveData(string key, object toSave);
        UniTask<T> LoadData<T>(string key);
    }
}