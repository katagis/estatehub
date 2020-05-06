using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EstateHub.model
{
    class User
    {
        public string Username { get; }
        public List<Notification> Notifications { get; }
        
        void RegisterNotification(Notification notification) {
            Notifications.Add(notification);
        }               

         


    }
}
