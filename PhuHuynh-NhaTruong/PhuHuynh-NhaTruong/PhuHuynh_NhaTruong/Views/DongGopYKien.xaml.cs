using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class DongGopYKien : ContentPage
    {
        public DongGopYKien()
        {
            InitializeComponent();
            UserInit();
        }

        private void UserInit()
        {
            var list = new DoiTuongDongGopItem[]
            {
                new DoiTuongDongGopItem
                {
                    Id = "0000",
                    DoiTuong = "What the fuck?",
                    DaChon = false, 
                },  
                new DoiTuongDongGopItem
                {
                    Id = "0001",
                    DoiTuong = "What the fuck?",
                    DaChon = true,
                },
                new DoiTuongDongGopItem
                {
                    Id = "0000",
                    DoiTuong = "What the fuck?",
                    DaChon = false,
                },
                new DoiTuongDongGopItem
                {
                    Id = "0001",
                    DoiTuong = "What the fuck?",
                    DaChon = true,
                },
                new DoiTuongDongGopItem
                {
                    Id = "0000",
                    DoiTuong = "What the fuck?",
                    DaChon = false,
                },
                new DoiTuongDongGopItem
                {
                    Id = "0001",
                    DoiTuong = "What the fuck?",
                    DaChon = true,
                },
            };

            TargetListView.ItemsSource = list;
        }

        private async void FeedbackButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DanhSachYKienDongGop());
        }

    }
}
