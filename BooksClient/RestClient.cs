// ===============================
// ©Copyright VISIONARY S.A.S.
// ===============================
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;

namespace BooksClient
{
    /// <summary>
    /// RestClient. Encapsulates and simplifies the REST code
    /// </summary>
    public sealed class RestClient : IDisposable
    {
        readonly HttpClient httpClient;

        public RestClient(string apiRoute)
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiRoute)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //
            Console.WriteLine($"Api Root: {apiRoute}");
        }

        public async Task<List<T>> GetAll<T>(string route)
        {
            try {
                var json = await httpClient.GetStringAsync(route);

                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception exception) {
                Console.WriteLine($"ERROR. GetAll(): {exception.Message}");
            }
            return null;
        }

        public async Task<T> Get<T>(string route, int pk) where T : class
        {
            try {
                var json = await httpClient.GetStringAsync($"{route}/{pk}/");
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception exception) {
                Console.WriteLine($"ERROR. Get(): {exception.Message}");
            }
            return default;
        }

        public async Task<T> Post<T>(string route, T item) where T : class
        {
            /*
            Important note about django API
            --------------------------------
            C# not implement short date, then the model use DateTime
            Serialized create the json as "Date":"YYYY-MM-DDTHH:MM:SS", i.g. "Date":"1976-01-12T00:00:00"
            The POST send in respose this error: 
                {"Date":["Date has wrong format. Use one of these formats instead: YYYY-MM-DD."]}
            For Django to accept this format, YYYY-MM-DDTHH:MM:SS, we must add to Settings.py:
            REST_FRAMEWORK = {
                "DATE_INPUT_FORMATS": ["%Y-%m-%d",'%Y-%m-%dT%H:%M:%S'],
            }
            */
            try {
                var serialized = new JsonContent<T>(item);

                var response = await httpClient.PostAsync(route, serialized);
                var js = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.Created) {
                    return JsonConvert.DeserializeObject<T>(js);
                } else {
                    Console.WriteLine($"Return: {js}");
                }
                return null;
            }
            catch (Exception exception) {
                Console.WriteLine($"ERROR. Post: {exception.Message}");
            }
            return null;
        }


        public void Dispose()
        {
            httpClient.Dispose();
        }
    }

    #region-- Utility for REST Asp.NEt Core --
    // https://goo.gl/cdJtaQ
    // best code, short code.
    public class JsonContent<T> : StringContent
    {
        public JsonContent(T obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }
    // for anonymus
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }
    // sample: new HttpClient().PostAsync("http://...", new JsonContent(new { x = 1, y = 2 });
    #endregion
}
