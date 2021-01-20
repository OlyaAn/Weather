using System.Net.Http;
using System.Text;

namespace WeaterForecast.Helpers
{
    public class HttpRequestHelper
    {
        private static HttpClient _httpClient = new HttpClient();

        public static string GetRequest(string path)
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, path))
            {
                var responseString = _httpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync().Result;

                return responseString;
            }
        }
    }
}
