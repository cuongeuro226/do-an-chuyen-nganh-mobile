using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuHuynh_NhaTruong.Models.LTN
{
    public class ThongBao
    {
        public string ID { get; set; }
        public string Thongbao_Code { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string TrangThai { get; set; }
        public string NguoiDuyet { get; set; }
        public Nullable<System.DateTime> NgayDuyet { get; set; }
    }
}
