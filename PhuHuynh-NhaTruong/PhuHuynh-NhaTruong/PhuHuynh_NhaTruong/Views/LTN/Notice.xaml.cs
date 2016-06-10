using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreFoundation;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhuHuynh_NhaTruong.Models;
using Xamarin.Forms; 
using UIKit;
using HomeKit; 
using PhuHuynh_NhaTruong.Models.LTN; 

namespace PhuHuynh_NhaTruong
{
    public partial class Notice : ContentPage
    {
        private MasterDetailPage mas;

        public Notice()
        { 
            InitializeComponent(); 
            lvNewsNotice.IsPullToRefreshEnabled = false; 
            SetItemsource();
            ReceiveNotificationFromAdmin(); 
        }
        public Notice(MasterDetailPage r)
        {
            mas = r;
            InitializeComponent();
            lvNewsNotice.IsPullToRefreshEnabled = false;
            SetItemsource();
            ReceiveNotificationFromAdmin();
        }

        private void LvNews_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
        private void Buttonmenu_OnClicked(object sender, EventArgs e)
        {
            mas.IsPresented = mas.IsPresented == true ? false : true;
        }

        public async void SetItemsource()
        {
            
            actiLoadding.IsVisible = true;
            lvNewsNotice.ItemsSource = await GetThongBao(lblErrorThongBao);
            actiLoadding.IsVisible = false;
        }

        public async Task<IEnumerable<PhuHuynh_NhaTruong.Models.LTN.ThongBao>> GetThongBao(View viewError)
        {
            var tempError = "";
            var flag = true;
            var result = new List<PhuHuynh_NhaTruong.Models.LTN.ThongBao>(); 
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Common.HOST);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent h = new StringContent(JsonConvert.SerializeObject(new { ID = Common.ID, Password = Common.PASSWORD }), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("api/ThongBaosApi/GetThongBaoByID", h);
                    ObjectApi temp = JsonConvert.DeserializeObject<ObjectApi>(await res.Content.ReadAsStringAsync());
                    if (temp.Status == true)
                    {
                        flag = true;
                        result = JsonConvert.DeserializeObject<List<PhuHuynh_NhaTruong.Models.LTN.ThongBao>>(temp.Data.ToString()) ;
                    }
                    else
                    {
                        flag = false;
                        tempError = temp.Message;
                    }
                }
            }
            catch(Exception ex)
            {
                tempError = "Lỗi xử lý ở sever... ";
                flag = false;
            }
            if (flag == false)
            {
                ((Label) viewError).Text = tempError;
                viewError.IsVisible = true;
            }
            return result;
        }


        public async void ReceiveNotificationFromAdmin()
        {
            var temp = new PushNotification();
            Common.CloseCurrentPush();
            Common.LISTPUSHNOTIFICATIONS.Add(temp); 
            await temp.Connect();

            temp.proxy.On("ReceiveNewNotificationFromAdmin", (string title, string name, string sender, string message) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {

                    await Pushnotification.TranslateTo(1000, 0, 300, Easing.SinIn);
                    lblPushNotification.Text = title + name + sender + message;
                    await Pushnotification.FadeTo(1, UInt32.MinValue, Easing.Linear);
                    await Pushnotification.TranslateTo(this.Width/2, 0, 300, Easing.SinIn);
                    btnExitPushNotification.BackgroundColor = Color.Red;
                    Pushnotification.BackgroundColor=Color.Yellow;
                    Device.StartTimer(TimeSpan.FromSeconds(20), TimerNotificationtick);
                }); 
            });
        }

        public  bool TimerNotificationtick()
        {
            HideNotification();
            return true;
        }

        ~Notice()
        { 
            Common.LISTPUSHNOTIFICATIONS.Clear(); 
        }

        private void HideNotification()
        {
            btnExitPushNotification.BackgroundColor= Color.Transparent;
            Pushnotification.FadeTo(0, uint.MinValue, Easing.Linear);
            Pushnotification.BackgroundColor = Color.Transparent;
        }
        private void ReloadNotification_OnTapped(object sender, EventArgs e)
        {
            HideNotification();
            SetItemsource();

        }

        private void BtnExitPushNotification_OnClicked(object sender, EventArgs e)
        {
            HideNotification();
        }

        private async void Item_OnTapped(object sender, EventArgs e)
        { 
            var r = await DisplayActionSheet("tiêu đề", "hủy", "ok", "1","2","3","4");
        }
    }
}
