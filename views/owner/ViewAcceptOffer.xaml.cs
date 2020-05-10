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
    /// Interaction logic for ViewAcceptOffer.xaml
    /// </summary>
    public partial class ViewAcceptOffer : Page
    {
        public ViewAcceptOffer() {
            InitializeComponent();

            var o = App.GetCurrentOwner();
            

            bool foundEstates = false;
            foreach (var estate in o.Estates){
                if (!(estate.CurrentDeal is null)) {
                    // TODO: Handle 0 offers
                    ui_estateList.Children.Add(new EstateElementControl(estate, "View " +  estate.ActiveOffers.Count + " offers", OnOfferSelected));
                    foundEstates = true;
                }
            }
            if (!foundEstates) {
                MessageBox.Show("No estates without deals found.");
            }
        }

        void OnOfferSelected(Estate estate) {
            MessageBox.Show(estate.Title);
        }

    }
}
