using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FoodOrderAppAPIGAteway.Utils
{
    public class Httpclient
    {
        private HttpClient client;
        public const string MediaTypeJson = "application/json";
        public const string RequestMsg = "Request not processed";

        public static string ReasonPhrase { get; set; }
        
        public Httpclient()
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback +=
                            (sender, certificate, chain, errors) =>
                            {
                                return true;
                            };
            this.client = new HttpClient(handler);
            this.client.DefaultRequestHeaders.Accept.Clear();

            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
        }

        public async Task<List<U>> RunAsyncGetAll<U>(dynamic uri)
        {
            HttpResponseMessage response = await this.client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<U>>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }

            throw new Exception(RequestMsg);
        }

        public async Task<U> RunAsyncPost<T, U>(string uri, T entity)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(uri, entity).Result;

            ReasonPhrase = response.ReasonPhrase;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<U>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }
            throw new Exception(RequestMsg);
        }

        public async Task<U> RunAsyncGet<T, U>(dynamic uri, dynamic data)
        {
            HttpResponseMessage response = await this.client.GetAsync(uri + "?Id=" + data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<U>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }
            throw new Exception(RequestMsg);
        }

        public async Task<U> RunAsyncPut<T, U>(string uri, T entity)
        {
            HttpResponseMessage response = client.PutAsJsonAsync(uri, entity).Result;

            ReasonPhrase = response.ReasonPhrase;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<U>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }
            throw new Exception(RequestMsg);
        }
    }
}
