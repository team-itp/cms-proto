using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CmsClient.Utils
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public HttpResponseMessage Response { get; }

        public HttpException(HttpStatusCode statusCode, HttpResponseMessage response)
        {
            StatusCode = statusCode;
            Response = response;
        }
    }

    public class HttpHelper
    {
        private static HttpClient httpClient = new HttpClient();

        public static string Bearer { get; set; }

        public static async Task<T> GetRequest<T>(Uri uri, bool isAuthRequired = true)
        {
            SetupAuthorizationHeader(isAuthRequired);
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            EnsureSuccessfullStatusCode(response);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public static async Task<T> PostRequest<T>(Uri uri, HttpContent content, bool isAuthRequired = true)
        {
            SetupAuthorizationHeader(isAuthRequired);
            var response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);
            EnsureSuccessfullStatusCode(response);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        private static void SetupAuthorizationHeader(bool isAuthRequired)
        {
            if (isAuthRequired)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Bearer);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        private static void EnsureSuccessfullStatusCode(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                case HttpStatusCode.Moved:
                    break;
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.NotFound:
                    throw new HttpException(response.StatusCode, response);
                default:
                    throw new HttpException(response.StatusCode, response);
            }
        }
    }
}
