using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PhuHuynh_NhaTruong
{
    public class ChiTietThongBao : ContentPage
    {
        public ChiTietThongBao(ThongBaoItem item)
        {
            Content = new StackLayout
            {
                Padding = new Thickness(20,20,20,20),
                Children = {
                    new Label { Text = item.TieuDe, FontSize = 20, TextColor = Color.Red},
                    new Label { Text = String.Format("Được gửi từ {0} ", item.NguoiGuiThongBao), FontSize = 10},
                    new Label { Text = item.NoiDung},
                }
            };
        }
    }
}
