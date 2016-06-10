using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuHuynh_NhaTruong.Annotations;
using Xamarin.Forms;
using System.Net;
using PhuHuynh_NhaTruong.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace PhuHuynh_NhaTruong
{
    public partial class Home : MasterDetailPage
    {
        NavigationPage navi = new NavigationPage();
        MasterDetailPage r = new MasterDetailPage();
        
        public  Home(NavigationPage nav)
        {
            navi = nav;
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this,false);
            InitializeComponent();
            r = this;
            this.Detail = new Notice(r);
        }

        // demo get and post by api _ LTN
        //public async Task abc()
        //{
        //    //using (var client = new HttpClient())
        //    //{
        //    //    client.BaseAddress = new Uri("http://localhost:31724/");
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    //    // GET
        //    //    //var response = await client.GetAsync("api/HocSinhsApi/GetHocSinh/MHS_20");
        //    //    //var r = await response.Content.ReadAsStringAsync();
        //    //    //var t = JsonConvert.DeserializeObject<HocSinh>(r);
        //    //    //POST
        //    //    //HttpContent h = new StringContent( JsonConvert.SerializeObject(new HocSinh {Ten = "ádasdasd"}), Encoding.UTF8, "application/json");
        //    //    //await client.PostAsync("api/HocSinhsApi/PostHocSinh", h );

        //    //}
        //}  

        private void Buttonmenu_OnClicked(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true;
        }

        private void ButtonXemThongTinTaiKhoan_OnClicked(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true;
            Detail = new Info(r);

        }

        private void ButtonXemDiem_OnClicked(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true;
            Detail = new Score(r);
        }

        private void ButtonXemThongBao_OnClicked(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true;
            Detail = new Notice(r);
        }

        private void ButtonPhanHoi_OnClicked(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true;
            // chua lam 
        }

        private void ButtonXemTinTuc_OnClicked(object sender, EventArgs e)
        {
            IsPresented = IsPresented == true ? false : true; 
            //ContentPageDetail.Content = new News();
            // chua co tin tuc tren sever
        }

        private async void ButtonThoat_OnClicked(object sender, EventArgs e)
        {
            Common.ID = "";
            Common.PASSWORD = "";
            await navi.PopToRootAsync();
            await navi.PushAsync(new Login(navi),true);
            navi.Navigation.RemovePage(navi.Navigation.NavigationStack.First());
        }
    }
}
