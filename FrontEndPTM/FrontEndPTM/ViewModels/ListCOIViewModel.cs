using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using FrontEndPTM.Models;
using FrontEndPTM.Services;
using System.Collections.ObjectModel;

namespace FrontEndPTM.ViewModels
{
    public class ListCOIViewModel : BindableObject
    {
        private string nama;
        private List<COIDetail> results;

        public ListCOIViewModel(string nama)
        {
            this.nama = nama;
            GetData();
        }

        private ObservableCollection<COIDetail> coiDetails;
        public ObservableCollection<COIDetail> COIDetails
        {
            get { return coiDetails; }
            set { coiDetails = value; OnPropertyChanged("COIDetails"); }
        }

        async void GetData()
        {
            COIService coiService = new COIService();
            results = await coiService.GetCOIByNamaStatus(nama);
            COIDetails = new ObservableCollection<COIDetail>(results);
        }
    }
}
