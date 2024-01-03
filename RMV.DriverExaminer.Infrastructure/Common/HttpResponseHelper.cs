
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RMV.DriverExaminer.Infrastructure.Common
{
    public static class HttpResponseHelper
    {
        public static async Task<T> ReadHttpContent<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(dataAsString);

           // return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        //public static Task<HttpResponseMessage> PostHttpContent<T>(this HttpClient httpClient, string url, T data)
        //{
        //    var dataAsString = JsonSerializer.Serialize(data);
        //    var content = new StringContent(dataAsString);
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    return httpClient.PostAsync(url, content);
        //}

        //public static Task<HttpResponseMessage> PutHttpContent<T>(this HttpClient httpClient, string url, T data)
        //{
        //    var dataAsString = JsonSerializer.Serialize(data);
        //    var content = new StringContent(dataAsString);
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    return httpClient.PutAsync(url, content);
        //}
    }
}
