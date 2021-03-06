﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views;
using Microsoft.AspNet.SignalR.Client;
using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public class App : Application
    {
        public App()
        {

            //ltn
            var temp = new NavigationPage();
            var t = new Login(temp);
            temp.PushAsync(t);
            MainPage = temp;


            // hide navigaionbar 
            NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetHasNavigationBar(temp, false);

             
            
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
