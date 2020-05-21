using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

namespace EstateHub.model
{
    public class User
    {
        public string Username { get; }
        public List<Notification> Notifications { get; } = new List<Notification>();
        
        public User(string name) {
            Username = name;
            Estatehub.RegisterUser(this);
        }

        public void RegisterNotification(Notification notification) {
            Notifications.Add(notification);
        }

        public override string ToString()  {
            return Username;
        }


    }
}
