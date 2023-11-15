using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericApiNetCore.ClientLib
{
    public class HttpClientWrapper
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

        public virtual async Task<IApiResult<TResult>> ExecuteAsync<TPayload, TResult>(IApiRequest<TPayload, TResult> request)
        {
            //get url
            var apiInfoRequestAtribute = request.GetType().GetCustomAttribute<ApiInfoRequestAtribute>(true) ?? throw new Exception($"Please use {nameof(ApiInfoRequestAtribute)} for {request.GetType().Name}");
            var url = apiInfoRequestAtribute.ApiUrl;

            //prepare api
            using var httpClient = new HttpClient();
            using var httpRequest = CreateRequestMessage(HttpMethod.Post, url, request);

            //execute api
            using var responseMessage = await httpClient.SendAsync(httpRequest);

            //read response
            try
            {
                var body = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ApiResult<TResult>>(body)
                    ?? throw new Exception($"{responseMessage.RequestMessage?.Method} {responseMessage.RequestMessage?.RequestUri} => {(int)responseMessage.StatusCode} {responseMessage.StatusCode} {body}");
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
