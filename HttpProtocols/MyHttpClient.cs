using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpProtocols
{
    public class MyHttpClient
    {
        private readonly HttpClient _httpClient;

        public MyHttpClient()
        {
            _httpClient = new HttpClient();
        }
        //public async Task<string> SendGetRequestAsync(string requestUrl)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
        //    response.EnsureSuccessStatusCode();

        //    return await response.Content.ReadAsStringAsync();
        //}

        public async Task<string> GET(string requestUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> POST(string requestUrl, Dictionary<string, string> parameters)
        {
            var content = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Response> GetDataAsync(string requestUrl)
        {
            try
            {
                string responseString = await GET(requestUrl);
                Response response = Response.DeserializeResponse(responseString);

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception("Error occurred while retrieving data from API", ex);
            }
        }

        public async Task<Response> GetDataAsync(string requestUrl, Dictionary<string, string> parameters)
        {
            try
            {
                string responseString = await POST(requestUrl, parameters);
                Response response = Response.DeserializeResponse(responseString);

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception("Error occurred while retrieving data from API", ex);
            }
        }
        internal void Dispose()
        {
            _httpClient.Dispose();
        }

    }
}
