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

namespace EstateHub
{
    /// <summary>
    /// Interaction logic for SelectionPage.xaml
    /// </summary>
    public partial class SelectionPage : Page
    {
        public SelectionPage() {
            InitializeComponent();
        }

        private void ui_submit_Click(object sender, RoutedEventArgs e) {
            string title = ui_formTitle.Text;
            string desc = ui_formDescription.Text;
            string region = ui_formDescription.Text;
            string postal = ui_formPostalCode.Text;
            string address = ui_formAddress.Text;
            // TODO: Check for duplicate location, validate all input

           MessageBox.Show("Error message.", "Register Estate", MessageBoxButton.OK);
        }
    }
}
