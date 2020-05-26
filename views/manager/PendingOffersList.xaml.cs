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

namespace EstateHub.views.manager
{
    /// <summary>
    /// Interaction logic for PendingOffersList.xaml
    /// </summary>
    public partial class PendingOffersList : Page
    {
        public PendingOffersList() {
            InitializeComponent();

            ui_offerList.Children.Clear();
            var manager = App.GetCurrentManager();

            if (manager.Offers.Count == 0) {
                MessageBox.Show("No pending offers found.");
                MainWindow.Instance.ChangeView("views/SearchResultsPage.xaml");
                return;
            }

            foreach (var offer in manager.Offers) {
                ui_offerList.Children.Add(new EstateElementControl(offer, "Cancel Offer", OnSelected));
            }
        }

        private void OnSelected(Offer offer) {
            if (MessageBoxResult.Yes ==  MessageBox.Show("Are you sure you want to cancel the current offer for " + offer.Estate.Title + "?", "", MessageBoxButton.YesNo)) {

                var manager = App.GetCurrentManager();
                manager.Offers.Remove(offer);
                offer.Estate.ActiveOffers.Remove(offer);

                MainWindow.Instance.ChangeView("views/manager/PendingOffersList.xaml");
                return;
            }
        }

    }
}
