using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhuHuynh_NhaTruong.Models;
using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class Notice : ContentView
    {
        public Notice()
        {
            InitializeComponent();
            SetItemsource();
            lvNewsNotice.IsPullToRefreshEnabled = true;
            
        }

        private void LvNews_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        
        public async Task SetItemsource()
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

       
    }
}
