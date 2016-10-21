using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FrontEndPTM.Models
{
    public class COIDetail : BindableObject
    {
        private string coiNumber;
        public string COINumber
        {
            get { return coiNumber; }
            set { coiNumber = value; OnPropertyChanged("COINumber"); }
        }

        private string polNumberq;
        public string PolNumber
        {
            get { return polNumberq; }
            set { polNumberq = value; OnPropertyChanged("PolNumber"); }
        }


        private int idTipeStatus;
        public int IdTipeStatus
        {
            get { return idTipeStatus; }
            set { idTipeStatus = value; OnPropertyChanged("IdTipeStatus"); }
        }

        public string DestinationPort { get; set; }
        public string VesselName { get; set; }

        private TipeStatus tipeStatus;
        public TipeStatus TipeStatus
        {
            get { return tipeStatus; }
            set { tipeStatus = value; OnPropertyChanged("TipeStatus"); }
        }

    }

    public class Pengguna
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdTipeUser { get; set; }

        public TipeUser TipeUser { get; set; }
    }

    public class TipeStatus
    {
        public TipeStatus()
        {
            this.CoiDetails = new List<COIDetail>();
        }

        public int IdTipeStatus { get; set; }
        public string NamaTipe { get; set; }

        public List<COIDetail> CoiDetails { get; set; }
    }

    public class TipeUser
    {
        public TipeUser()
        {
            this.Penggunas = new List<Pengguna>();
        }

        public int IdTipeUser { get; set; }
        public string NamaTipe { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsRequest { get; set; }
        public bool IsReview { get; set; }
        public bool IsApprove { get; set; }
        public bool IsAccept { get; set; }

        public List<Pengguna> Penggunas { get; set; }
    }

    public class CIStatusView : BindableObject
    {
        private string namaTipe;
        public string NamaTipe
        {
            get { return namaTipe; }
            set { namaTipe = value; OnPropertyChanged("NamaTipe"); }
        }

        private int jumlah;
        public int Jumlah
        {
            get { return jumlah; }
            set { jumlah = value; OnPropertyChanged("Jumlah"); }
        }
    }
}
