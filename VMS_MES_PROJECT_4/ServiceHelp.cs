using Newtonsoft.Json;
using MESDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VMS_MES_PROJECT_4
{
    //nuget 설치필요
    //1. Newtonsoft.Json
    //2. Microsoft.AspNet.WebApi.Client
    public class ServiceHelp : IDisposable
    {
        HttpClient client = new HttpClient();

        public string BaseServiceUrl { get; set; }

        public ServiceHelp(string routePrefix)
        {
            BaseServiceUrl = $"{ConfigurationManager.AppSettings["ApiAddress"]}/{routePrefix}";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetListAsync<T>(string path, T t)
        {
            path = BaseServiceUrl + path;

            T list = default(T);
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        list = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    }
                }
                return list;
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
                return list;
            }
        }

        public async Task<T> GetAsync<T>(string path, T t)
        {
            path = BaseServiceUrl + path;

            T obj = default(T);
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Message<T> msg = JsonConvert.DeserializeObject<Message<T>>(await response.Content.ReadAsStringAsync());
                        obj = msg.Data;
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public async Task<Message> GetAsync(string path)
        {
            path = BaseServiceUrl + path;

            Message msg = null;
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        msg = JsonConvert.DeserializeObject<Message>(await response.Content.ReadAsStringAsync());
                    }
                }
                return msg;
            }
            catch
            {
                return msg;
            }
        }

        public async Task<Message<T>> PostAsync<T>(string path, T t)
        {
            path = BaseServiceUrl + path;

            Message<T> result = null;
            try
            {
                using (HttpResponseMessage response = await client.PostAsJsonAsync(path, t))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<Message<T>>(await response.Content.ReadAsStringAsync());
                    }
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public async Task<Message> PostAsyncNone<T>(string path, T t)
        {
            path = BaseServiceUrl + path;
            //https://localhost:44337/api/User/SaveUser

            Message result = null;
            try
            {
                using (HttpResponseMessage response = await client.PostAsJsonAsync(path, t))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<Message>(await response.Content.ReadAsStringAsync());
                    }
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
