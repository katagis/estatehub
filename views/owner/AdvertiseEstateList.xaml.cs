using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EstateHub.model;

namespace EstateHub.views.owner
{
    /// <summary>
    /// Interaction logic for AdvertiseEstateList.xaml
    /// </summary>
    public partial class AdvertiseEstateList : Page
    {
        public AdvertiseEstateList() {
            InitializeComponent();

            var owner = App.GetCurrentOwner();

            ui_estateList.Children.Clear();

            if (owner.Estates.Count == 0) {
                MessageBox.Show("No estates found.");
                MainWindow.Instance.ChangeView("views/MainMenu.xaml");
                return;
            }

            foreach (var estate in owner.Estates) {
                string statusText;
                if (!estate.IsCurrentlyAvailable()) {
                    statusText = "_Already Managed";
                }
                else if (estate.IsBeingAdvertised()) {
                    statusText = "_Already Advertised";
                }
                else {
                    statusText = "Advertise";
                }

                ui_estateList.Children.Add(new EstateElementControl(estate, statusText, OnSelected));
            }
        }

        public void OnSelected(Estate estate) {
            MainWindow.Instance.ChangeView(new AdvertiseEstate(estate));
        }

    }
}
