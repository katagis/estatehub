using System;
using System.Collections.Generic;
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
            string region = ui_formRegion.Text;
            string postal = ui_formPostalCode.Text;
            string address = ui_formAddress.Text;
            // TODO: Check for duplicate location, validate all input

            Func<string, string, bool> isEmpty = (string str, string fieldname) =>
            {
                if (string.IsNullOrWhiteSpace(str)) {
                    MessageBox.Show("Estate must have a" + fieldname);
                    return true;
                }
                return false;
            };

            if (isEmpty(title, " title")
                || isEmpty(region, " region")
                || isEmpty(postal, " postal code")
                || isEmpty(address, "n address")) {
                return;
            }

            if (title.Length < 8) {
                MessageBox.Show("Title length must be at least 8 characters");
                return;
            }


            Location loc = new Location() { Address = address, Region = region, PostalCode = postal };

            if (Estatehub.DoesLocationExist(loc)) {
                MessageBox.Show("Duplicate estate, location already registered in EstateHub.");
                return;
            }


            Estate estate = new Estate(App.GetCurrentOwner(), loc, title, desc);
            Estatehub.RegisterLocation(loc);
            App.GetCurrentOwner().RegisterEstate(estate);

            MessageBox.Show("Estate " + title + " added successfully.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow.Instance.ChangeView("views/MainMenu.xaml");
        }


        private void TextboxRegexFilter(TextBox box, string regexPattern) {
            var cursorPosition = box.SelectionStart;
            box.Text = Regex.Replace(box.Text, regexPattern, "");
            box.SelectionStart = cursorPosition;
        }

        private void ui_formPostalCode_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter(ui_formPostalCode, "[^0-9]");
        }

        private void ui_formTitle_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter(ui_formTitle, "[^A-Za-z ]");
        }
    }
}
