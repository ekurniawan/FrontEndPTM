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
    public class COIStatusViewModel : BindableObject
    {
        private List<CIStatusView> results;

        private ObservableCollection<CIStatusView> coiStatus;
        public ObservableCollection<CIStatusView> COIStatus
        {
            get { return coiStatus; }
            set { coiStatus = value; OnPropertyChanged("COIStatus"); }
        }

        async void GetData()
        {
            COIService coiService = new COIService();
            results = await coiService.GetStatus();
            COIStatus = new ObservableCollection<CIStatusView>(results);
        }

        //private List<CIStatusView> coiStatus;
        //public List<CIStatusView> COIStatus
        //{
        //    get { return coiStatus; }
        //    set { coiStatus = value; OnPropertyChanged("COIStatus"); }
        //}

        //async void GetData()
        //{
        //    COIService coiService = new COIService();
        //    COIStatus = await coiService.GetStatus();
        //}

        public COIStatusViewModel()
        {
            GetData();
            //COIStatus = new ObservableCollection<CIStatusView>(results);
        }
    }
}
