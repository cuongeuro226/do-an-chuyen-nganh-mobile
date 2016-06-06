using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PhuHuynh_NhaTruong.Models;
using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class Login : ContentPage
    {
        private NavigationPage nav;
        public Login(NavigationPage cnav)
        {
            nav = cnav;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
       

        private async void Onclick_Submit(object sender, EventArgs e)
        {
            acti.IsVisible = true;
            await ProcessLogin();
            acti.IsVisible = false;
        }

        public async Task ProcessLogin()
        {
            var tempError = "";
            var flag = true;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Common.HOST);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent h = new StringContent(JsonConvert.SerializeObject(new { ID = enttId.Text, Password = entPassWord.Text }), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("api/TaiKhoansApi/CheckTaiKhoan", h);
                    ObjectApi temp = JsonConvert.DeserializeObject<ObjectApi>(await res.Content.ReadAsStringAsync());
                    if (temp.Status == true)
                    {
                        if ((bool)temp.Data)
                        {
                            flag = true;
                            Common.ID = enttId.Text;
                            Common.PASSWORD = entPassWord.Text;
                        }
                        else
                        {
                            flag = false;
                            tempError = "Tài khoản không chính xác, thử lại ....";
                        }
                    }
                    else
                    {
                        flag = false;
                        tempError = temp.Message;
                    }
                }
            }
            catch
            {
                tempError = "Lỗi xử lý sever... ";
                flag = false;
            }

            if (flag == false)
            {
                lblError.BindingContext = new { error = tempError, iserror = true };
            }
            else
            { 
                await nav.PushAsync(new Home()); 
                //var t = nav.Navigation.NavigationStack.First();
                //NavigationPage.SetHasNavigationBar(t, false);
                //NavigationPage.SetHasNavigationBar(nav, false);

                //push page
                //nav.Navigation.InsertPageBefore(new Home(),nav.Navigation.NavigationStack.First());
                //nav.Navigation.PopAsync();

                //                nav.Navigation.RemovePage(nav.Navigation.NavigationStack.First());

                //push page
                //await nav.Navigation.PushAsync(new Home(), true); 
                //var temp =new NavigationPage();
                //await temp.PushAsync(new Home(), true);
                //nav = temp; 
            }
        }


    }
}
