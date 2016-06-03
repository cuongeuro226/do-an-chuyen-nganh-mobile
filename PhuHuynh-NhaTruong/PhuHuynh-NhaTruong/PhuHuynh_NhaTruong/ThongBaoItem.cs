using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PhuHuynh_NhaTruong.Annotations;

namespace PhuHuynh_NhaTruong
{
    public class ThongBaoItem : INotifyPropertyChanged
    {
        private string _tieuDe;
        private string _noiDung;
        private ThongBaoTu _thongBaoTu;
        private string _nguoiGuiThongBao;

        public ThongBaoItem()
        {
            _thongBaoTu = ThongBaoTu.NhaTruong;
            _nguoiGuiThongBao = "Nhà trường";
        }
        public string TieuDe
        {
            get { return _tieuDe; }
            set
            {
                if (_tieuDe != value)
                {
                    _tieuDe = value;
                    OnPropertyChanged("TieuDe");
                }
            }
        }

        public string NoiDung {
            get { return _noiDung; }
            set
            {
                if (value != null && _noiDung != value)
                {
                    _noiDung = value;
                    OnPropertyChanged("NoiDung");
                }
            } }

        public ThongBaoTu ThongBaoTu
        {
            get { return _thongBaoTu; }
            set
            {
                if (value != null && value != _thongBaoTu)
                {
                    _thongBaoTu = value;
                    OnPropertyChanged("ThongBaoTu");
                }
            }
        }

        public string NguoiGuiThongBao
        {
            get
            {
                return _nguoiGuiThongBao;
            }

            set
            {
                if (value != null && value != _nguoiGuiThongBao )
                {
                    if (ThongBaoTu == ThongBaoTu.GiaoVien)
                    {
                        _nguoiGuiThongBao = value;
                    }
                    OnPropertyChanged("NguoiGuiThongBao");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public enum ThongBaoTu
    {
        NhaTruong, 
        GiaoVien
    }
}

