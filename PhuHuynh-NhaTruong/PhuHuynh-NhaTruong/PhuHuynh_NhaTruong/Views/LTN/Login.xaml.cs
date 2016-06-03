using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class Login : ContentPage
    {
        private NavigationPage nav;
        private Page tem;

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        public Login(NavigationPage temp)
        {
            InitializeComponent();
            // cho 1 service chayj ngam hoac 1 db local,
            nav = temp;
            //
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Onclick_Submit(object sender, EventArgs e)
        {
            if (enttId.Text == "1" && entPassWord.Text == "1")
            {
                //xử lý dâtbase.gét json
                nav.Navigation.PushAsync(new Home(), true);
                nav.Navigation.RemovePage(nav.Navigation.NavigationStack.ElementAt(0));
            }
            else
            {
                lblError.BindingContext = new { error = "loi ", iserror = true };
            }
        }
    }
}
