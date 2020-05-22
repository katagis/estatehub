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
    public partial class ManagerElementControl : UserControl
    {
        public delegate void OnSelected(Manager estate, Offer offer);

        public OnSelected SelectedCallback;

        private Offer offer;
        public ManagerElementControl(Manager manager, string btnText, OnSelected callback, Offer _offer = null) {
            InitializeComponent();
            DataContext = manager;
            btn_Text.Text =  btnText;
            SelectedCallback = callback;
            offer = _offer;

            if (offer is null) {
                ui_offer.Visibility=Visibility.Collapsed;
            }
            else {
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.NumberGroupSeparator = ".";
                ui_offerAmount.Text = offer.Money.ToString("N0", nfi) + " \x20AC";

                ui_offerSeasons.Text = offer.SeasonsLeft;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e) {
            SelectedCallback((Manager)DataContext, offer);
        }
    }
}
