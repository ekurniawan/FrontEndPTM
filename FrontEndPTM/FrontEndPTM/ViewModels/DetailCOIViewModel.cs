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
    public class DetailCOIViewModel : BindableObject
    {
        private string noCOI;

        public DetailCOIViewModel(string coiNumber)
        {
            noCOI = coiNumber;
            GetData();
        }

        private COIDetail coiDetailItem;
        public COIDetail COIDetailItem
        {
            get { return coiDetailItem; }
            set { coiDetailItem = value; OnPropertyChanged("COIDetailItem"); }
        }

        async void GetData()
        {
            COIService coiService = new COIService();
            COIDetailItem = await coiService.GetCOIById(noCOI);
        }
    }
}
