using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuHuynh_NhaTruong.Models
{
    public static class Common
    {
        public static String ID { get; set; }
        public static String PASSWORD { get; set; }

       // public static String HOST = "http://localhost:31724/"; 
        public static String HOST = "http://chuyennganhweb.azurewebsites.net/";

        public static List<PushNotification> LISTPUSHNOTIFICATIONS = new List<PushNotification>();
        public static bool CloseCurrentPush()
        {
            try
            {
                foreach (var item in Common.LISTPUSHNOTIFICATIONS)
                {
                    item.Cancle();
                }
                Common.LISTPUSHNOTIFICATIONS.Clear();
            }
            catch (Exception)
            {

                return false;
            }

            return true;

        }
    }
}
