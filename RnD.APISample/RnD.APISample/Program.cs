using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;

namespace RnD.APISample
{
    class Program
    {
        private const string url = "https://tcomx4.screenslicer.com/screenslicer/query-keyword";
        //private const string url = "https://screenslicer.ssl/screenslicer/query-keyword";
        //https://screenslicer.ssl/screenslicer/query-keyword
        private const string data = @"{
        ""instances"": ""tcomx4.screenslicer.com"",
        ""site"": ""http://www.dice.com"",
        ""keywords"": ""asp.net mvc""}";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start...");

                #region Old Code

                //var urlAuthor = "https://tcomx4.screenslicer.com/screenslicer/query-keyword";
                //var clientAuthor = new HttpClient();
                //clientAuthor.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BASIC", "ZGV2OjJrMWVabDFnNnVuRDdJMmphT2s2V2o=");
                //clientAuthor.DefaultRequestHeaders.Host = "POST";
                //clientAuthor.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var responseAuthor = clientAuthor.GetAsync(urlAuthor).Result;

                //var url = "https://tcomx4.screenslicer.com/screenslicer/query-keyword?instances=104.131.222.77&site=http://www.dice.com&keywords=asp.net mvc";
                //var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BASIC", "ZGV2OjJrMWVabDFnNnVuRDdJMmphT2s2V2o=");
                //client.DefaultRequestHeaders.Host = "POST";
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var response = client.GetAsync(url).Result;

                #endregion

                #region by Authorization

                //System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                //client.BaseAddress = new System.Uri(url);
                ////byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
                ////byte[] cred = UTF8Encoding.UTF8.GetBytes("dev:2k1eZl1g6unD7I2jaOk6Wj");
                //byte[] cred = UTF8Encoding.UTF8.GetBytes("ZGV2OjJrMWVabDFnNnVuRDdJMmphT2s2V2o=");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("BASIC", Convert.ToBase64String(cred));
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //System.Net.ServicePointManager.Expect100Continue = false;
                //System.Net.Http.HttpContent content = new StringContent(data, UTF8Encoding.UTF8, "application/json");
                //HttpResponseMessage messge = client.PostAsync(url, content).Result;
                //string description = string.Empty;
                //if (messge.IsSuccessStatusCode)
                //{
                //    string result = messge.Content.ReadAsStringAsync().Result;
                //    description = result;
                //}

                #endregion

                #region Like JavaScript

                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Method = "POST";
                //request.ContentType = "application/json";
                //request.ContentLength = data.Length;
                //using (Stream webStream = request.GetRequestStream())
                //using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                //{
                //    requestWriter.Write(data);
                //}

                //try
                //{
                //    WebResponse webResponse = request.GetResponse();
                //    using (Stream webStream = webResponse.GetResponseStream())
                //    {
                //        if (webStream != null)
                //        {
                //            using (StreamReader responseReader = new StreamReader(webStream))
                //            {
                //                string response = responseReader.ReadToEnd();
                //                Console.Out.WriteLine(response);
                //            }
                //        }
                //    }
                //}
                //catch (Exception e)
                //{
                //    Console.Out.WriteLine("-----------------");
                //    Console.Out.WriteLine(e.Message);
                //}

                #endregion

                #region By Faz

                string clientBaseAddress = "https://tcomx4.screenslicer.com/";
                //string clientBaseAddress = "https://recruit.theladders.com/";
                string credCode = "dev:2k1eZl1g6unD7I2jaOk6Wj";
                string strContent1 = @"{""instances"": [""104.131.215.49""],""site"": ""http://www.dice.com"",""keywords"": ""asp.net mvc""}";
                //"preSearchClicks":[{"innerText":"Don't show this again"}], "preAuthClicks":[{"innerText":"Sign In >","href":"https://recruit.theladders.com/login"}]
                //string strContent2 = @"{""instances"":[""104.131.215.49""], ""site"":""https://recruit.theladders.com/"", ""keywords"":""asp.net mvc"", ""fetch"":true, ""credentials"":{""username"":""nill_akash_7@hotmail.com"",""password"":""admin123#@""}}";
                string strContent2 = @"{""instances"":[""104.131.215.49""], ""site"":""https://recruit.theladders.com/"", ""keywords"":""asp.net mvc"", ""fetch"":true, ""credentials"":{""username"":""nill_akash_7@hotmail.com"",""password"":""admin123#@""}, ""preSearchClicks"":[{""innerText"":""Don't show this again""}], ""preAuthClicks"":[{""innerText"":""Sign In >"",""href"":""https://recruit.theladders.com/login""}]}";
                
                GetApiData(clientBaseAddress, credCode, strContent2);

                #endregion

                Console.WriteLine("End...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void GetApiData(string clientBaseAddress, string credCode, string strContent)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(clientBaseAddress);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credCode);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("BASIC",
                Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.Http.HttpContent content = new StringContent(strContent, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync("screenslicer/query-keyword", content).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;

                var dataList = JsonConvert.DeserializeObject<object>(description);

            }
        }
    }
}
