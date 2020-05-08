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

        App() {
            // Insert our dummy data...
            new Manager("Icefox & Co.");
            new Manager("At Sea Management");

            CurrentUser =  new Owner("Corona Smith");
            new Owner("Software Engineer");
            new Owner("Alexander Foobar");

        }

        public void ChangeUser(User newUser) {
            CurrentUser = newUser;
            (MainWindow as MainWindow)?.InitializeForUser(newUser);
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
