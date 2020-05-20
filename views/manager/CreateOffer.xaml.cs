using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateOffer.xaml
    /// </summary>
    public partial class CreateOffer : Page
    {
        private Estate estate;

        public CreateOffer() {
            InitializeComponent();
        }

        private void ui_submit_Click(object sender, RoutedEventArgs e) {

        }

        private void ui_seasons_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ui_amount_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
