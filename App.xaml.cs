using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EstateHub.model;

namespace EstateHub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance { get => Current as App; }
        public User CurrentUser { get; private set; }

        public void ChangeUser(User newUser) {
            var oldUser = CurrentUser;
            CurrentUser = newUser;
            UserChanged(oldUser, newUser);
        }

        private void UserChanged(User oldUser, User newUser) {
            // TODO: Notify the required views.
        }

        public Manager GetManager() {
            if (!(CurrentUser is Manager)) {
                MessageBox.Show("User session was not manager. Code requested a manager.");
                // TODO: Get default manager user and return it.
            }
            return CurrentUser as Manager;
        }

        public Owner GetOwner() {
            if (!(CurrentUser is Owner)) {
                MessageBox.Show("User session was not owner. Code requested a owner.");
                // TODO: Get default owner user and return it.
            }
            return CurrentUser as Owner;
        }
    }
}
