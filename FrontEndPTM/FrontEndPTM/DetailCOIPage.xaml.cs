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

       

        async void GetData()
        {
            COIDetail data = (COIDetail)BindingContext;

            TipeStatusService tipeStatusServices = new TipeStatusService();

            //await DisplayAlert("Keterangan", "Tipe Status " + IdTipeStatusInt.ToString(), "OK");

            TipeStatus statusPrev = await tipeStatusServices.GetStatusPrev(data.IdTipeStatus.ToString());
            btnStatusPrev.Text = statusPrev.NamaTipe;

            TipeStatus statusNext = await tipeStatusServices.GetStatusNext(data.IdTipeStatus.ToString());
            btnStatusNext.Text = statusNext.NamaTipe;
        }

        public DetailCOIPage()
        {
            InitializeComponent();

            GetData();
            //var result = new DetailCOIViewModel(coiNumber).COIDetailItem;
            //BindingContext = new DetailCOIViewModel(coiNumber).COIDetailItem;
            //this.coiNumber = coiNumber;
            //GetData();
            //this.BindingContext = result;


            //DisplayAlert("Keterangan", "COI " + result. ,"OK");

            btnStatusPrev.Clicked += BtnStatusPrev_Clicked;
            btnStatusNext.Clicked += BtnStatusNext_Clicked;
        }

        private async void BtnStatusNext_Clicked(object sender, EventArgs e)
        {
            COIService coiService = new COIService();
            COIDetail updateCoi = (COIDetail)BindingContext;

            updateCoi.IdTipeStatus += 1;

            coiService.Update(updateCoi.COINumber, updateCoi);

            await Navigation.PopAsync();
        }

        private async void BtnStatusPrev_Clicked(object sender, EventArgs e)
        {
            COIService coiService = new COIService();
            COIDetail updateCoi = (COIDetail)BindingContext;
            updateCoi.IdTipeStatus -= 1;

            coiService.Update(updateCoi.COINumber, updateCoi);

            await Navigation.PopAsync();
        }
    }
}
