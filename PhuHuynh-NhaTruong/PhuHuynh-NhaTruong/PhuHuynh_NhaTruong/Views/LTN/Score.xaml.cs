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
    public partial class Score : ContentPage
    {
        private MasterDetailPage mas ;
        public Score()
        {
            InitializeComponent();
            SetItemsource();
            lvScore.IsPullToRefreshEnabled = false; 
        }
        public Score(MasterDetailPage r)
        {
            mas = r;
            InitializeComponent();
            SetItemsource();
            lvScore.IsPullToRefreshEnabled = false;
        }

        private void Buttonmenu_OnClicked(object sender, EventArgs e)
        {
            mas.IsPresented = mas.IsPresented == true ? false : true;
        }

        public async Task SetItemsource()
        {
            actiLoaddingScore.IsVisible = true;
            lvScore.ItemsSource = await GetDiem(lblErrorThongBaoScore);
            actiLoaddingScore.IsVisible = false;
        }

        public async Task<IEnumerable<Diem>> GetDiem(View viewError)
        {
            var tempError = "";
            var flag = true;
            var result = new List<Diem>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Common.HOST);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent h = new StringContent(JsonConvert.SerializeObject(new { ID = Common.ID, Password = Common.PASSWORD }), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("api/DiemsApi/GetDiemByID", h);
                    ObjectApi temp = JsonConvert.DeserializeObject<ObjectApi>(await res.Content.ReadAsStringAsync()); 
                    if (temp.Status == true)
                    {
                        flag = true;
                        result = JsonConvert.DeserializeObject<List<Diem>>(temp.Data.ToString());
                        foreach (var item in result)
                        {
                            item.diem = new Diem
                            {
                                idhocky = item.idhocky,
                                diem = item.diem,
                                idlop = item.idlop,
                                namhoc = item.namhoc,
                                tenLop = item.tenLop,
                                tenhocky = item.tenhocky
                            };
                        }
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
                tempError = "Lỗi xử lý sever... ";
                flag = false;
            }
            if (flag == false)
            {
                ((Label)viewError).Text = tempError;
                viewError.IsVisible = true;
            }
            return result;
        }
         
        private void LvNews_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }


        private async void ButtonDiemCNhan_OnClicked(object sender, EventArgs e)
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
                    // 
                    HttpContent h = new StringContent(JsonConvert.SerializeObject(new
                        {
                            idlop =((Diem)((Button)sender).CommandParameter).idlop,
                            idhocky = ((Diem)((Button)sender).CommandParameter).idhocky,
                            taikhoan = new
                            {
                                ID = Common.ID, Password = Common.PASSWORD 
                            
                            }
                        }), Encoding.UTF8, "application/json");
                    //
                    var res = await client.PostAsync("api/DiemsApi/GetDiemCaNhanByID", h);
                    ObjectApi temp = JsonConvert.DeserializeObject<ObjectApi>(await res.Content.ReadAsStringAsync());
                    if (temp.Status == true)
                    {
                        flag = true;
                        if ((bool)temp.Data)
                        {
                             // get file
                        }
                        else
                        {
                            flag = false;
                            tempError = temp.Message;
                        }
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
                tempError = "Lỗi xử lý sever... ";
                flag = false;
            }
            if (flag == false)
            {
                ((Label)lblErrorThongBaoScore).Text = tempError;
                lblErrorThongBaoScore.IsVisible = true;
            }

        }


    }
}
