using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using FrontEndPTM.Models;
using FrontEndPTM.ViewModels;

using FrontEndPTM.Services;

namespace FrontEndPTM
{
    public partial class DetailCOIPage : ContentPage
    {
        //private string coiNumber;
        //private COIDetail result;

        //async void GetData()
        //{
        //    COIService coiService = new COIService();
        //    COIDetail result = await coiService.GetCOIById(coiNumber);
        //    this.result = result;
        //    //await DisplayAlert("Keterangan", "COI " + result.COINumber, "OK");
        //}

        private int IdTipeStatusInt;

        async void GetData()
        {
            TipeStatusService tipeStatusServices = new TipeStatusService();

            //await DisplayAlert("Keterangan", "Tipe Status " + IdTipeStatusInt.ToString(), "OK");

            TipeStatus statusPrev = await tipeStatusServices.GetStatusPrev(IdTipeStatusInt.ToString());
            btnStatusPrev.Text = statusPrev.NamaTipe;

            TipeStatus statusNext = await tipeStatusServices.GetStatusNext(IdTipeStatusInt.ToString());
            btnStatusNext.Text = statusPrev.NamaTipe;
        }

        public DetailCOIPage(int idTipeStatus)
        {
            InitializeComponent();

            IdTipeStatusInt = idTipeStatus;

            GetData();
            //var result = new DetailCOIViewModel(coiNumber).COIDetailItem;
            //BindingContext = new DetailCOIViewModel(coiNumber).COIDetailItem;
            //this.coiNumber = coiNumber;
            //GetData();
            //this.BindingContext = result;


            //DisplayAlert("Keterangan", "COI " + result. ,"OK");
        }

        
    }
}
