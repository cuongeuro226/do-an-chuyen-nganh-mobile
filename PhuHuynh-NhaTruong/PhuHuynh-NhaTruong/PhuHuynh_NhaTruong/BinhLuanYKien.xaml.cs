using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class BinhLuanYKien : ContentPage
    {

        public static ObservableCollection<BinhLuanItem> BinhLuans = new ObservableCollection<BinhLuanItem>();
        public BinhLuanYKien()
        {
            InitializeComponent();
            UserInit();
        }

        private void UserInit()
        {

            BinhLuans.Add(new BinhLuanItem
            {
                Id = "comment001",
                NguoiBinhLuan = "Nhà trường",
                NoiDung = "Chúng tôi đã tiếp nhận ý kiến, chúng tôi sẽ quan tâm nhiều hơn đến học sinh, cảm ơn đã đóng góp ý kiến!"
            });
            BinhLuans.Add(new BinhLuanItem
            {
                Id = "comment002",
                NguoiBinhLuan = "Nguyễn Văn A",
                NoiDung = "Cảm ơn nhà trường đã tiếp nhận phản hồi"
            });


            CommentListView.ItemsSource = BinhLuans;
        }


        private void CommentButton_OnClicked(object sender, EventArgs e)
        {
            BinhLuans.Add(new BinhLuanItem
            {
                Id = "comment001",
                NguoiBinhLuan = "Nhà trường",
                NoiDung = "Chúng tôi đã tiếp nhận ý kiến, chúng tôi sẽ quan tâm nhiều hơn đến học sinh, cảm ơn đã đóng góp ý kiến!"
            });
            BinhLuans.Add(new BinhLuanItem
            {
                Id = "comment002",
                NguoiBinhLuan = "Nguyễn Văn A",
                NoiDung = "Cảm ơn nhà trường đã tiếp nhận phản hồi"
            });
        }
    }
}
