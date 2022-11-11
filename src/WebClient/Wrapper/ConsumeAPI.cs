using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebModel.StudentModel;

namespace WebClient.Wrapper
{
    public class ConsumeAPI<T> : IDisposable where T : class
    {
        string strWebApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];

        public IEnumerable<T> generaticReadAsAsyncs(string ApiUrlRoute)
        {
            IEnumerable<T> objs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(strWebApiUrl);
                var responseTask = client.GetAsync(ApiUrlRoute);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<T>>();
                    readTask.Wait();

                    objs = readTask.Result;
                }
            }
            return objs;
        }

        public T generaticReadAsAsync(string ApiUrlRoute)
        {
            T obj = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(strWebApiUrl);
                var responseTask = client.GetAsync(ApiUrlRoute);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();

                    obj = readTask.Result;
                }
            }
            return obj;
        }

        public T generaticPutAsJsonAsync(string ApiUrlRoute, T objT)
        {
            T obj = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(strWebApiUrl);
                var responseTask = client.PutAsJsonAsync<T>(ApiUrlRoute, objT);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();

                    obj = readTask.Result;
                }
            }
            return obj;
        }

        public T generaticPostAsJsonAsync(string ApiUrlRoute, T objT)
        {
            T obj = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(strWebApiUrl);
                var responseTask = client.PostAsJsonAsync<T>(ApiUrlRoute, objT);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();

                    obj = readTask.Result;
                }
            }
            return obj;
        }

        public T generaticDeleteAsync(string ApiUrlRoute)
        {
            T obj = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(strWebApiUrl);
                var responseTask = client.DeleteAsync(ApiUrlRoute);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();

                    obj = readTask.Result;
                }
            }
            return obj;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}