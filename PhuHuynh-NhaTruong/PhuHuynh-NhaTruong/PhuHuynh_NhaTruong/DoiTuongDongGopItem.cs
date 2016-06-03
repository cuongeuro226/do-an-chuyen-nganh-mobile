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
    class DoiTuongDongGopItem : INotifyPropertyChanged
    {
        private string _id;
        private string _doiTuong;
        private bool _daChon;
        public string DoiTuong
        {
            get
            {
                return _doiTuong;
            }

            set
            {
                if (value != null && value != _doiTuong)
                {
                    _doiTuong = value;
                    OnPropertyChanged("DoiTuong");
                }
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value != null && value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public bool DaChon
        {
            get
            {
                return _daChon;
            }

            set
            {
                if (value != null && value != _daChon)
                {
                    _daChon = value;
                    OnPropertyChanged("DaChon");
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
}
