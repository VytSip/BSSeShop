using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WEB.APIConnector
{
    public class ApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        private readonly Uri _baseEndpoint;

        public ApiClient()
        {
            _baseEndpoint = new Uri("https://localhost:44345/api/");

            _httpClient = new HttpClient()
            {
                BaseAddress = _baseEndpoint
            };
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary> 
        public async Task<T> GetAsync<T>(string requestUrl, string queryString = "")
        {
            var requestUri = CreateRequestUri(requestUrl, queryString);

            var response = await _httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary> 
        public async Task<T> PostAsync<T>(string requestUrl, T content, string queryString = "")
        {
            try
            {
                var requestUri = CreateRequestUri(requestUrl, queryString);
                var httpContent = CreateHttpContent<T>(content);
                var testingTemp = httpContent.ReadAsStringAsync().Result;
                var response = await _httpClient.PostAsync(requestUri.ToString(), httpContent);
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary> 
        public async Task<T> PutAsync<T>(string requestUrl, T content, string queryString = "")
        {
            try
            {
                var requestUri = CreateRequestUri(requestUrl, queryString);
                var httpContent = CreateHttpContent<T>(content);
                var response = await _httpClient.PutAsync(requestUri.ToString(), httpContent);
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T1> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            var httpContent = CreateHttpContent<T2>(content);

            var response = await _httpClient.PostAsync(requestUrl.ToString(), httpContent);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T1>(data);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        #region Private methods

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(_baseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint)
            {
                Query = queryString
            };

            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, DateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings DateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    NullValueHandling = NullValueHandling.Ignore
                };
            }
        }

        #endregion
    }
}
