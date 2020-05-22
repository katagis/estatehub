using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for ViewAcceptOffer.xaml
    /// </summary>
    public partial class ViewAcceptOffer : Page
    {
        private Estate estateSelected;
        public ViewAcceptOffer() {
            InitializeComponent();

            var o = App.GetCurrentOwner();

            ui_estateList.Children.Clear();
            bool foundEstates = false;
            foreach (var estate in o.Estates){
                if (estate.CurrentDeal is null) {
                    ui_estateList.Children.Add(new EstateElementControl(estate, "View " +  estate.ActiveOffers.Count + " offers", OnEstateSelected));
                    foundEstates = true;
                }
            }
            if (!foundEstates) {
                MessageBox.Show("No estates without deals found.");
                MainWindow.Instance.ChangeView("views/MainMenu.xaml");
            }
        }

        void OnOfferSelected(Manager manager, Offer offer) {
            string msgTxt =
                    "Are you sure you want to accept this offer for " + estateSelected.Title + "?\n" +
                    "From: " + manager.Username + "\n" +
                    "" + offer.SeasonsLeft + " for " + offer.Money + " \x20AC";

            if (MessageBox.Show(msgTxt, "Accept Offer", MessageBoxButton.YesNo) ==  MessageBoxResult.Yes) {
                offer.AcceptOffer();
                MessageBox.Show("Offer accepted.");
                MainWindow.Instance.ChangeView("views/MainMenu.xaml");
            }
        }

        void OnEstateSelected(Estate estate) {
            
            if (estate.ActiveOffers.Count == 0) {
                MessageBox.Show("No offers available for " + estate.Title);
                return;
            }
            estateSelected = estate;
            ui_subpageTitle.Text = "Accept offer for " + estate.Title + ":";

            ui_estateList.Children.Clear();

            foreach (var offer in estate.ActiveOffers) {
                ui_estateList.Children.Add(new ManagerElementControl(offer.Offerer, "Accept offer", OnOfferSelected, offer));
            }
        }

    }
}
