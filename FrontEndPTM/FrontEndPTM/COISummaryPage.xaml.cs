using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using FrontEndPTM.ViewModels;
using FrontEndPTM.Models;

namespace FrontEndPTM
{
    public partial class COISummaryPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new COIStatusViewModel();
        }

        public COISummaryPage()
        {
            InitializeComponent();

            //BindingContext = new COIStatusViewModel();

            myListView.ItemTapped += MyListView_ItemTapped;
        }

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (CIStatusView)e.Item;
            var status = data.NamaTipe;

            await Navigation.PushAsync(new ListCOIPage(status));
        }
    }
}
