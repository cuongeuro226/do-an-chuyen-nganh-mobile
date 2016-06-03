using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class Score : ContentView
    {
        public Score()
        {
            InitializeComponent();
            var t = new List<asd>
            {
                 new  asd {Name= "1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1"},new asd {Name="1end---"},new asd {Name="end"}
            };
            lvScore.IsPullToRefreshEnabled = false;
            lvScore.ItemsSource = t;
        }

        private void LvNews_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

    }
}
