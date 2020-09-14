using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TehranEnergyApiClient.Web.HttpClientExtensions.Serialization
{
    public class JsonDeserializer : IDeserializer
    {
        public T Deserialize<T>(string json) where T : class
        {
            return string.IsNullOrEmpty(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }
    }
}
