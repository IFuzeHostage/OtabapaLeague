using Newtonsoft.Json;

namespace OtabapaLeague.Domain.Systems.DataSerializer
{
    public class JsonDataSerializer : IDataSerializer
    {
        public string Serialize<T>(T toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }

        public T Deserialize<T>(string toDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(toDeserialize);
        }
    }
}