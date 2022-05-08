using APILayer.Models;
using DomainLayer.DTO;
using DomainLayer.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UILayer.Datas.Apiservices
{
    public class Adminapi
    {
        public IEnumerable<Registration> GetUserInfo()
        {

            UserResponse<IEnumerable<Registration>> _responseModel = new UserResponse<IEnumerable<Registration>>();
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44364/api/admin/GetAll";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    _responseModel.result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Registration>>(response.Result);
                }

                return _responseModel.result;
            }
        }
        public bool AdminLogin(LoginView AdminLogin)
       
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(AdminLogin);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/Admin/post";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
