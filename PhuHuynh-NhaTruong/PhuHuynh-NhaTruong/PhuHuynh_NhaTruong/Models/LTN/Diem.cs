using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuHuynh_NhaTruong.Models
{
    public class Diem
    {
        public  String idlop { get; set; } 
        public String tenLop { get; set; } 
        public String namhoc { get; set; }
        public String idhocky { get; set; }
        public String tenhocky { get; set; } 
        public Diem diem { get; set; }
    }
}
