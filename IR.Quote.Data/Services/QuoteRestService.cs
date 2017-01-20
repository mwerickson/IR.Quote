using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IR.Quote.Data.Helpers;
using IR.Quote.Data.RequestResponse;
using Newtonsoft.Json;

namespace IR.Quote.Data.Services
{
    public interface IQuoteRestService
    {
        Task<QuoteResponse> GetQuotes(QuoteRequest request);
    }

    public class QuoteRestService : IQuoteRestService
    {
        private string _baseUrl = "https://some.url.here";
        private string _authToken;

        public QuoteRestService()
        {
            
        }

        private async Task<TResponse> SendRequest<TRequest, TResponse>(string url, TRequest request) where TResponse : BaseResponse
        {
            using (var client = GetClient())
            {
                try
                {
                    Trace.Message($"Calling REST: {_baseUrl} : {url}");
                    client.BaseAddress = new Uri(_baseUrl);
                    var payload = new StringContent(JsonConvert.SerializeObject(request).ToString(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, payload);
                    Trace.Message("Back from REST call");
                    if (!response.IsSuccessStatusCode)
                    {
                        TResponse returnObj = (TResponse)Activator.CreateInstance(typeof(TResponse));
                        try
                        {
                            var respString = response.Content.ReadAsStringAsync().Result;
                            var errorData = JsonConvert.DeserializeObject<TResponse>(respString);
                            if (errorData != null)
                            {
                                returnObj.Message = errorData.Message;
                                returnObj.DetailedMessage = errorData.DetailedMessage;
                                returnObj.ErrorCode = errorData.ErrorCode;
                            }
                        }
                        catch (Exception)
                        {
                            returnObj.Message = "Unknown API Error";
                            returnObj.DetailedMessage = response.StatusCode.ToString();
                            returnObj.ErrorCode = -1;
                        }

                        Trace.Message($"Call to {_baseUrl} : {url} failed: {response.StatusCode}");
                        return returnObj;
                    }
                    var rawResponseString = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<TResponse>(rawResponseString);
                    Trace.Message($"Call to {_baseUrl} : {url} success");
                    return data;
                }
                catch (TaskCanceledException tcex)
                {
                    var x = tcex.Message;
                    return default(TResponse);
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return default(TResponse);
                }
            }
        }

        private HttpClient GetClient()
        {
            Trace.Message("Getting http client");
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(_authToken))
            {
                Trace.Message($"Adding auth header {_authToken}");
                client.DefaultRequestHeaders.Add("Authorization", $"Token {_authToken}");
            }

            //if (!string.IsNullOrEmpty(_deviceToken))
            //{
            //    Trace.Message($"Adding device token header {_deviceToken}");
            //    client.DefaultRequestHeaders.Add("device-token", _deviceToken);
            //}
            //else
            //{
            //    Trace.Message("*** NOT *** adding device token to header, it is null or empty.");
            //}

            client.DefaultRequestHeaders.Add("user-agent", "CustomAppAgentHere");
            Trace.Message("Http client created");
            return client;
        }

        public async Task<QuoteResponse> GetQuotes(QuoteRequest request)
        {
            return await SendRequest<QuoteRequest, QuoteResponse>("/quote/all", request);
        }
    }
}