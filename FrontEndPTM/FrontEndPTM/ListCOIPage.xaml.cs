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

        public ListCOIPage(string status)
        {
            InitializeComponent();
            BindingContext = new ListCOIViewModel(status);


            myListView.ItemTapped += MyListView_ItemTapped;
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            COIDetail result = (COIDetail)e.Item;
            DetailCOIPage detailPage = new DetailCOIPage(result.IdTipeStatus);
            detailPage.BindingContext = result;
            
            
            Navigation.PushAsync(detailPage);
        }
    }
}
