using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class ThongBao : ContentPage
    {
        public static ObservableCollection<ThongBaoItem> ThongBaos = new ObservableCollection<ThongBaoItem>();

        public ThongBao()
        {
            InitializeComponent();
            UserInit();
        }

        private void UserInit()
        {

            for (int i = 0; i < 10; i++)
            {
                ThongBaoItem item  = new ThongBaoItem
                {
                    TieuDe = "Đóng học phí",
                    NoiDung = "Từ ngày xx đến yy nhà trường thông báo cho phụ huynh chuẩn bị tiền học phí cho con em.",
                    ThongBaoTu =  ThongBaoTu.NhaTruong
                    
                };
                ThongBaos.Add(item);
            }
            ThongBaos.Add(new ThongBaoItem
            {
                TieuDe = "Lao động vì môi trường",
                NoiDung = "Tôi là giáo viên chủ nhiệm lớp X, thông báo ngày xx/yy/zz các phụ huynh mang dụng cụ đến tại trường A để làm lao động cho con em của mình.",
                ThongBaoTu = ThongBaoTu.GiaoVien,
                NguoiGuiThongBao = "Nguyễn Thị Thảo"

            });
            NotificationListView.ItemsSource = ThongBaos;


        }

        private async void NotificationListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new ChiTietThongBao((ThongBaoItem)e.SelectedItem));
        }
    }
}
