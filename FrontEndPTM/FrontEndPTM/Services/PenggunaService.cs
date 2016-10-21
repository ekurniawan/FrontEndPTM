using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrontEndPTM.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace FrontEndPTM.Services
{
    public class PenggunaService
    {
        private RestClient _client;

        public PenggunaService()
        {
            _client = new RestClient("http://ptmapp.azurewebsites.net/");
        }

        public async Task<Pengguna> GetLogin(Pengguna pengguna)
        {
            var request = new RestRequest("api/Pengguna/GetLogin", Method.POST);
            request.AddBody(pengguna);

            var response = await _client.Execute<Pengguna>(request);

            return response.Data;
        }
    }
}
