using DemoApiCalls.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemoApiCalls.Services
{
    public class APICallsService
    {
        private static readonly string baseURL = "https://127.0.0.1/v1/inputs";
        //private static readonly string baseURL = "https://localhost:44308/v1/inputs";

        public static async Task<IRestResponse<object>> GetAllInputsFromAPI()
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{baseURL}");

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.GET);

            // Prepare request header
            // No information on header?
            try
            {
                response = await ExecuteAsync<object>(serviceClient, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }

        public static async Task<IRestResponse<object>> GetSpecificInputFromAPI()
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{baseURL}/0");

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.GET);

            // Prepare request header
            // No information on header?
            try
            {
                response = await ExecuteAsync<object>(serviceClient, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }

        public static async Task<IRestResponse<object>> GetInputForSlot1FromAPI()
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{baseURL}?slot-num=1");

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.GET);

            // Prepare request header
            // No information on header?
            try
            {
                response = await ExecuteAsync<object>(serviceClient, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }

        public static async Task<IRestResponse<object>> SetColorsOnAPI()
        {
            #region SSL Addendum
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            #endregion

            IRestResponse<object> response;

            Uri apiCallUri = new Uri($"{baseURL}");

            

            // Prepare REST service communication

            RestClient serviceClient = new RestClient(apiCallUri);
            RestRequest request = new RestRequest(Method.PUT);

            // Prepare request header
            request.AddHeader(@"Accept", @"application/json");
            try
            {
                request.AddParameter("application/json", PrepareJsonForPost(), ParameterType.RequestBody);

                response = await ExecuteAsync<object>(serviceClient, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in API Call. Message: {ex.Message}");
                return null;
            }

            return response;
        }

        public static string PrepareJsonForPost()
        {
            string result = string.Empty;
            ColorsUpdateModel message = new ColorsUpdateModel()
            {
                InputId = 1,
                InputRedGain = 80,
                InputGreenGain = 85,
                InputBlueGain = 70
            };

            return JsonConvert.SerializeObject(message);
        } 

        public static async Task<IRestResponse<T>> ExecuteAsync<T>(RestClient serviceClient, RestRequest request) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            serviceClient.ExecuteAsync<T>(request, (responseTask) => taskCompletionSource.SetResult(responseTask));

            var response = await taskCompletionSource.Task;
            return response;
        }


    }
}
