using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericApiNetCore.ClientLib
{
    public class HttpClientWrapper : IDisposable
    {
        public virtual HttpRequestMessage CreateRequestMessage<T>(HttpMethod method, string? requestUri, T payload)
        {
            var jsonRequest = JsonSerializer.Serialize(payload);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json"),
            };
            return httpRequest;
        }

        public void Dispose()
        {

        }

        public virtual async Task<IApiResult<TResult>> ExecuteAsync<TPayload, TResult>(IApiRequest<TPayload, TResult> request, Uri baseAddress)
        {
            //get url
            var url = request.GetApiUrl();

            //prepare api
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = baseAddress;
            using var httpRequest = CreateRequestMessage(HttpMethod.Post, url, request);

            //execute api
            using var responseMessage = await httpClient.SendAsync(httpRequest);

            //read response
            try
            {
                var body = await responseMessage.Content.ReadAsStringAsync();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var apiResult = JsonSerializer.Deserialize<ApiResult<TResult>>(body, options);
                    if (apiResult != null) return apiResult;
                }
                throw new Exception($"{responseMessage.RequestMessage?.Method} {responseMessage.RequestMessage?.RequestUri} => {(int)responseMessage.StatusCode} {responseMessage.StatusCode} {body}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine(httpRequest.Content);
                return ApiResultFactory.FromException<TResult>(ex);
            }
        }
    }
}
