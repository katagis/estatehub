using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EstateHub.model
{
    public class Notification
    {
        public User ForUser { get; }
        public string Text { get; set; }

        public Notification(User forUser, string text) {
            ForUser = forUser;
            Text = text;
        }
    }
}
