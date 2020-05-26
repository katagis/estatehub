using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace EstateHub.views
{
    /// <summary>
    /// Interaction logic for EstateElementControl.xaml
    /// </summary>
    public partial class EstateElementControl : UserControl
    {
        public delegate void OnEstateSelected(Estate estate);
        public delegate void OnOfferSelected(Offer estate);

        private OnEstateSelected SelectedCallback;
        private OnOfferSelected SelectedOfferCallback;

        private Offer offer;
        

        public EstateElementControl(Estate estate, string btnText, OnEstateSelected callback) {
            InitializeComponent();
            DataContext = estate;
            InitializeBtn(btnText);
            SelectedCallback = callback;
        }

        public EstateElementControl(Offer inOffer, string btnText, OnOfferSelected callback) {
            InitializeComponent();
            offer = inOffer;
            DataContext = offer.Estate;
            InitializeBtn(btnText);
            SelectedOfferCallback = callback;

            ui_offerDetails.Visibility = Visibility.Visible;
            
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = ".";
            ui_offerAmount.Text = offer.Money.ToString("N0", nfi) + " \x20AC";
            ui_offerSeasons.Text = offer.SeasonsLeft;
        }

        private void InitializeBtn(string btnText) {
            if (string.IsNullOrEmpty(btnText)) {
                btn_button.Visibility = Visibility.Collapsed;
            }
            else if (btnText.StartsWith('_')) {
                btn_button.IsEnabled = false;
                btn_Text.Text =  btnText.Substring(1);
                btn_Text.Foreground = Brushes.Black;
            }
            else {
                btn_Text.Text =  btnText;
            }
        }
       
        public EstateElementControl() {
            InitializeComponent();
            DataContext = new Estate(null, new Location(55), "Ceid Estate");
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            if (!(SelectedCallback is null)) {
                SelectedCallback((Estate)DataContext);
            }
            else if (!(SelectedOfferCallback is null)) {
                SelectedOfferCallback(offer);
            }
        }
    }
}
