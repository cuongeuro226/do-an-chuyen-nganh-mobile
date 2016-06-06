using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuHuynh_NhaTruong.Models
{
    class HocSinh
    {
         
            public string ID { get; set; }
            public string HS_Code { get; set; }
            public string Ho { get; set; }
            public string Ten { get; set; }
            public Nullable<System.DateTime> NgaySinh { get; set; }
            public string DanToc { get; set; }
            public string GioiTinh { get; set; }
            public string HoTenCha { get; set; }
            public string HoTenMe { get; set; }
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            public Nullable<System.DateTime> NgayTao { get; set; }
            public string NguoiTao { get; set; }
            public string TrangThai { get; set; }
            public string NguoiDuyet { get; set; }
            public Nullable<System.DateTime> NgayDuyet { get; set; }

             
}
}
