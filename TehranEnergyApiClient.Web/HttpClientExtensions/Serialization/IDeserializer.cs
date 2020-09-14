

namespace TehranEnergyApiClient.Web.HttpClientExtensions.Serialization
{
    public interface IDeserializer
    {
        T Deserialize<T>(string json) where T : class;
    }
}
