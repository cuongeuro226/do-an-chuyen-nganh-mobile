using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public partial class DanhSachYKienDongGop : ContentPage
    {
        public DanhSachYKienDongGop()
        {
            InitializeComponent();
            UserInit();
        }

        private void UserInit()
        {
            var list = new YKienItem[]
            {
                new YKienItem
                {
                    Id =  "feedback01",
                    TieuDe = "Học sinh Trần Văn X",
                    NoiDung = "Sửa chưa quạt trần phòng xxx",
                    DoiTuongHuongToi = "Nguyen Van A"
                }, 
                new YKienItem
                {
                    Id = "feedback002",
                    TieuDe = "Hóc sinh Nguyễn Thị Hòe",
                    NoiDung = "Nha truong can quan tam hoc sinh hon",
                    DoiTuongHuongToi = "Nhà trường"
                }, 
            };
            FeedbackList.ItemsSource = list;
        }
    }
}
