using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using FrontEndPTM.Models;
using FrontEndPTM.Services;

namespace FrontEndPTM
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            btnLogin.Clicked += BtnLogin_Clicked;
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            PenggunaService penggunaService = new PenggunaService();
            Pengguna objPengguna = new Pengguna
            {
                Username = entryUsername.Text,
                Password = entryPassword.Text
            };

            Pengguna result = await penggunaService.GetLogin(objPengguna);

            if(result!=null)
            {
                Application.Current.Properties["profil"] = result;
                //await DisplayAlert("Keterangan", "Berhasil Login", "OK");
                await Navigation.PushAsync(new COISummaryPage());
            }
            else
            {
                await DisplayAlert("Keterangan", "Gagal Melakukan Login", "OK");
            }
        }
    }
}
