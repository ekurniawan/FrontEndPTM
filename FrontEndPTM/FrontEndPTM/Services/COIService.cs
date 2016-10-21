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
    //jangan lupa pengaturan
    //ganti solution porperti menjadi release untuk Android
    //tambahkan System.Net.Http dan Restsharp PCL
    public class COIService
    {
        private RestClient _client;

        public COIService()
        {
            _client = new RestClient("http://ptmapp.azurewebsites.net/");
        }

        public async Task<List<CIStatusView>> GetStatus()
        {
            var request = new RestRequest("api/COIDetail/GetStatus", Method.GET);

            var response = await _client.Execute<List<CIStatusView>>(request);

            return response.Data;
        }

        public async Task<List<COIDetail>> GetCOIByNamaStatus(string nama)
        {
            var request = new RestRequest("api/COIDetail/GetCOIByNamaStatus/{nama}", Method.GET);
            request.AddParameter("nama", nama, ParameterType.UrlSegment);

            var response = await _client.Execute<List<COIDetail>>(request);

            return response.Data;
        }

        public async Task<COIDetail> GetCOIById(string coiNumber)
        {
            var request = new RestRequest(string.Format("api/COIDetail/{0}",coiNumber), Method.GET);
            //request.AddParameter("id", coiNumber, ParameterType.UrlSegment);

            var response = await _client.Execute<COIDetail>(request);

            return response.Data;
        }

        public async void Update(string id, COIDetail model)
        {
            var request = new RestRequest(string.Format("api/COIDetail/{0}", id), Method.PUT);
            request.AddBody(model);

            var response = await _client.Execute(request);
        }


    }
}
