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
        public ViewAcceptOffer() {
            InitializeComponent();

            var o = App.GetCurrentOwner();

            ui_estateList.Children.Clear();
            bool foundEstates = false;
            foreach (var estate in o.Estates){
                if (estate.CurrentDeal is null) {
                    // TODO: Handle 0 offers
                    ui_estateList.Children.Add(new EstateElementControl(estate, "View " +  estate.ActiveOffers.Count + " offers", OnEstateSelected));
                    foundEstates = true;
                }
            }
            if (!foundEstates) {
                MessageBox.Show("No estates without deals found.");
                MainWindow.Instance.ChangeView("views/MainMenu.xaml");
            }
        }

        void OnManagerSelected(Manager manager) {

        }

        void OnEstateSelected(Estate estate) {
            
            if (estate.ActiveOffers.Count == 0) {
                MessageBox.Show("No offers available for " + estate.Title);
                return;
            }

            ui_estateList.Children.Clear();

            foreach (var offer in estate.ActiveOffers) {
                ui_estateList.Children.Add(new ManagerElementControl(offer.Offerer, "Accept offer", OnManagerSelected));
            }
        }

    }
}
