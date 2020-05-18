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

        public delegate void OnFollow();

        public OnFollow OnFollowDel{ get; }

        public Notification(User forUser, string text) {
            ForUser = forUser;
            Text = text;
        }
    }
}
