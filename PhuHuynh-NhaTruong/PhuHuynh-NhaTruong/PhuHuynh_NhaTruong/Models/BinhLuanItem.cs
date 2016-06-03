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
    public class BinhLuanItem : INotifyPropertyChanged
    {
        string _id;
        string _noiDung;
        string _nguoiBinhLuan;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public string NoiDung
        {
            get { return _noiDung; }
            set
            {
                if (value != null && value != _noiDung)
                {
                    _noiDung = value;
                    OnPropertyChanged("NoiDung");
                }
            }
        }

        public string NguoiBinhLuan
        {
            get { return _nguoiBinhLuan; }
            set
            {
                if (value != null && value != _nguoiBinhLuan)
                {
                    _nguoiBinhLuan = value;
                    OnPropertyChanged("NguoiBinhLuan");
                }
            }
        }
    }
}
