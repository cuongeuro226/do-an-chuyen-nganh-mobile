using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR; 
using System.Net; 
using Microsoft.AspNet.SignalR.Client;
using PhuHuynh_NhaTruong.Models;

namespace PhuHuynh_NhaTruong
{
    
    public class PushNotification
    {
        
        private HubConnection connection;
        public IHubProxy proxy { get; set; }
        //
        public PushNotification()
        { 
            connection = new HubConnection(Common.HOST);
            proxy = connection.CreateHubProxy("Ltn");
        }


        public async Task Connect()
        {
            await connection.Start(); 
 
        }
         
        //receive
        public async Task<Tuple<object, object, object, object>> ReceiveNewNotification()
        {
            await Connect();
            Tuple<object, object, object, object> result = null;
             proxy.On("ReceiveNewNotificationFromAdmin", (string title, string name, string sender, string message) =>
            {
                result = new Tuple<object, object, object, object>(title,name, sender, message);
            });
            return result;
        }
         
        public async Task<Tuple<object, object, object,object>> ReceiveNewScore()
        {
            await Connect();
            Tuple<object, object, object,object> result = null;
            proxy.On("ReceiveNewScore", (string title, string name, string sender, string message) =>
            {
                result = new Tuple<object, object, object,object>(title,name, sender, message);
            });
            return result;
        }

        public void Cancle()
        {
              connection.Stop();
        }
    }
}
