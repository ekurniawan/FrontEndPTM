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
    public class TipeStatusService
    {
        private RestClient _client;

        public TipeStatusService()
        {
            _client = new RestClient("http://ptmapp.azurewebsites.net/");
        }

        public async Task<TipeStatus> GetStatusPrev(string id)
        {
            var request = new RestRequest("api/TipeStatus/GetPrev/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = await _client.Execute<TipeStatus>(request);

            return response.Data;
        }

        public async Task<TipeStatus> GetStatusNext(string id)
        {
            var request = new RestRequest("api/TipeStatus/GetNext/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = await _client.Execute<TipeStatus>(request);

            return response.Data;
        }
    }
}
