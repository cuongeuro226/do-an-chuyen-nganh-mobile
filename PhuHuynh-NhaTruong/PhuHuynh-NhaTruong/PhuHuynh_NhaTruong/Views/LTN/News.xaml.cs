using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class News : ContentView
    {
        public News()
        {
            InitializeComponent();
            var t = new List<asd>
            {
                new asd { Name=@"European association representing the interests of industries in the aeronautics, space, defence and security sectors.
What Is Autism Spectrum Disorder? - AboutKidsHealth
www.aboutkidshealth.ca/en/resourcecentres/.../whatisasd/.../default.asp...
Dị  Hosting"},new  asd {Name= "1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1end---"},new asd {Name="end"}
            };
            lvNews.IsPullToRefreshEnabled = true;
            lvNews.ItemsSource = t;
        }

        private void LvNews_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }


    }

    public class asd
    {
        public String Name { get; set; }

    }
}
