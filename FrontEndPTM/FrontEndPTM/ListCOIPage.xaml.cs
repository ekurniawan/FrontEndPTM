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
    public partial class ListCOIPage : ContentPage
    {
        public ListCOIPage()
        {
            InitializeComponent();
        }

        private string status=string.Empty;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            string status = (string)Application.Current.Properties["status"];
            BindingContext = new ListCOIViewModel(status);
        }

        public ListCOIPage(string status)
        {
            InitializeComponent();
            Application.Current.Properties["status"] = status;
            myListView.ItemTapped += MyListView_ItemTapped;
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            COIDetail result = (COIDetail)e.Item;
            DetailCOIPage detailPage = new DetailCOIPage();
            detailPage.BindingContext = result;
            Navigation.PushAsync(detailPage);
        }
    }
}
