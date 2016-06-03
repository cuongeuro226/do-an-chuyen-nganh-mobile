using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class Home : MasterDetailPage
    {
        public Home()
        {
            InitializeComponent();
            IsPresented = false;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void a(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true;
        }

        private void onClicked(object sender, EventArgs e)
        {
            IsPresented = false;
            //ContentPageDetail.Children.Clear();
            //ContentPageDetail.Children.Add(new Detailn());



        }
    }
}
