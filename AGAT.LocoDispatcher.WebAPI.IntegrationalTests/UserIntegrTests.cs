using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AGAT.LocoDispatcher.WebAPI.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace AGAT.LocoDispatcher.WebAPI.IntegrationalTests
{
    [TestClass]
    public class UserIntegrTests
    {
        [TestMethod]
        public async Task InvokeDeletingITestOk()
        {
            try
            {
                string token = await GetTokenAsync();
                object countries = await GetCountriesAsync();
                Assert.IsNotNull(countries);
            }
            catch (Exception exception)
            {
                throw;
            }

        }
          
        private async Task<string> GetTokenAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    UserViewModel user = new UserViewModel
                    {
                        Username = "Alex",
                        Password = "010101"
                    };
                    var nvc = new List<KeyValuePair<string, string>>();
                    nvc.Add(new KeyValuePair<string, string>("Username", user.Username));
                    nvc.Add(new KeyValuePair<string, string>("Password", user.Password));

                    HttpContent content = new FormUrlEncodedContent(nvc);
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.RequestUri = new Uri(" http://192.168.111.110/api/user".Trim());
                    request.Content = content;
                    request.Method = HttpMethod.Post;
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpContent responseContent = response.Content;
                        var json = await responseContent.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new HttpRequestException();
                    }
                    return "";
                }
            }
            catch (Exception exception)
            {
                throw;
            }
          
        }

        private async Task<object> GetCountriesAsync()
        {
            using (var http = new HttpClient())
            {
                //https://restcountries.eu/rest/v2/all
                var response = await http.GetAsync("https://restcountries.eu/rest/v2/all");
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(data);
        
            }
        }
    }
}
