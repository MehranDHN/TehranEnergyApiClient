using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.Web.HttpClientExtensions.Serialization;

namespace System.Net.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadJsonAsync<T>(this HttpResponseMessage httpResponseMessage) where T : class
        {
            var content = httpResponseMessage.Content;

            if (content == null)
                return null;

            var contentType = content.Headers.ContentType.MediaType;
            if (!contentType.Contains(TehranEnergyApiClient.Web.HttpClientExtensions.Constants.ContentTypes.Json))
                throw new HttpRequestException($"Content type \"{contentType}\" not supported");

            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var jsonDeserializer = new JsonDeserializer();

            return jsonDeserializer.Deserialize<T>(json);
        }
    }
}
