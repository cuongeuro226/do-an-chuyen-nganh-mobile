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
    public class YKienItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _id;
        string _tieuDe;
        string _noiDung;
        string _doiTuongHuongToi;

        public string Id
        {
            get { return _id; }
            set
            {
                if (value != null && value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string TieuDe
        {
            get { return _tieuDe; }
            set
            {
                if (value != null && _tieuDe != value)
                {
                    _tieuDe = value;
                    OnPropertyChanged("TieuDe");
                }
            }
        }


        public string NoiDung
        {
            get { return _noiDung; }
            set
            {
                if (value != null && _noiDung != value)
                {
                    _noiDung = value;
                    OnPropertyChanged("NoiDung");
                }

            }
        }

        public string DoiTuongHuongToi
        {
            get { return _doiTuongHuongToi; }
            set
            {
                if (value != null && value != _doiTuongHuongToi)
                {
                    _doiTuongHuongToi = value;
                    OnPropertyChanged("DoiTuongHuongToi");
                }
            }
        }
    }
}
