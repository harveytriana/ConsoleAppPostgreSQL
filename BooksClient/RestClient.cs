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

namespace BooksClient
{
    /// <summary>
    /// RestClient. Encapsulates and simplifies the REST code
    /// </summary>
    public sealed class RestClient: IDisposable
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
