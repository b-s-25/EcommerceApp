﻿using APILayer.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using DomainLayer.DTO;
using DomainLayer.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.Datas.Apiservices
{
    public class UserApi
    {
        public UserApi(IConfiguration configuration)
        {
        }
        public bool UserRegister(RegistrationView user)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/User/SignUp";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //getuser data
        public IEnumerable<Registration> GetUserInfo()
        {

            UserResponse<IEnumerable<Registration>> _responseModel = new UserResponse<IEnumerable<Registration>>();
            using (HttpClient httpclient = new HttpClient())
            {
                _responseModel = null;
                string url = "https://localhost:44364/api/User/SignUp";
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

        public bool EditUserInfo(Registration userInfo)
        {
            using (HttpClient httpclient = new HttpClient())
{
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(userInfo);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/User/SignUp";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PutAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
