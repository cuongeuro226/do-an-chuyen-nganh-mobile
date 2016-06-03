using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new PhuHuynh_NhaTruong.ThongBao();
            //ltn
            var temp = new NavigationPage();
            temp.PushAsync(new Home());
            MainPage = temp;
            // hide navigaionbar 
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasNavigationBar(temp, false);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
