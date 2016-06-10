using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhuHuynh_NhaTruong.Models;
using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public  partial class Info : ContentPage
    {
        private MasterDetailPage mas;

        public Info()
        {
            InitializeComponent();
            Getdata();
        }

        public Info(MasterDetailPage r)
        {
            mas = r;
            InitializeComponent();
            Getdata();
        }

        private void Buttonmenu_OnClicked(object sender, EventArgs e)
        {
            mas.IsPresented = mas.IsPresented == true ? false : true;
        }

        public async void Getdata()
        {
            actiLoaddinglblErrorInfo.IsVisible = true;
            await GetInfo(lblErrorInfo);
            actiLoaddinglblErrorInfo.IsVisible = false;
        }

        public async Task GetInfo(View viewError)
        {
            var tempError = "";
            var flag = true;
             HocSinh result = new HocSinh();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Common.HOST);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent h = new StringContent(JsonConvert.SerializeObject(new { ID = Common.ID, Password = Common.PASSWORD }), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("api/TaiKhoansApi/GetInfo", h);
                    ObjectApi temp = JsonConvert.DeserializeObject<ObjectApi>(await res.Content.ReadAsStringAsync());
                    if (temp.Status == true)
                    {
                        flag = true;
                        result = JsonConvert.DeserializeObject<HocSinh>(temp.Data.ToString());
                    }
                    else
                    {
                        flag = false;
                        tempError = temp.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                tempError = "Lỗi xử lý ở sever... ";
                flag = false;
            }
            if (flag == false)
            {
                ((Label)viewError).Text = tempError;
                viewError.IsVisible = true;
            }
            BindingContext = result;

        }


    }
}
