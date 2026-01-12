namespace OtabapaLeague.Domain.Systems.DataSerializer
{
    public interface IDataSerializer
    {
        string Serialize<T>(T toSerialize);
        T Deserialize<T>(string toDeserialize);
    }
}