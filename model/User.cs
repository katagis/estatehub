using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EstateHub.model
{
    public class User
    {
        public string Username { get; }
        public List<Notification> Notifications { get; }
        
        public User(string name) {
            Username = name;
            Database.RegisterUser(this);
        }

        void RegisterNotification(Notification notification) {
            Notifications.Add(notification);
        }               

         


    }
}
