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

namespace EstateHub.views.owner
{
    /// <summary>
    /// Interaction logic for AdvertiseEstate.xaml
    /// </summary>
    public partial class AdvertiseEstate : Page
    {
        private Estate estate;

        public AdvertiseEstate(Estate inEstate) {
            estate = inEstate;
            DataContext = estate;
            InitializeComponent();
            ui_title.Text = "Advertise estate " + estate.Title + ":";
        }


        private void TextboxRegexFilter(TextBox box, string regexPattern) {
            var cursorPosition = box.SelectionStart;
            box.Text = Regex.Replace(box.Text, regexPattern, "");
            box.SelectionStart = cursorPosition;
        }


        private void ui_submit_Click(object sender, RoutedEventArgs e) {
            int season;
            try {
                season = Int32.Parse(ui_seasons.Text);
            }
            catch {
                MessageBox.Show("Seasons must be a positive number");
                return;
            }
            if (season <= 0) {
                MessageBox.Show("Seasons must be a positive number");
                return;
            }

            if (ui_cardnumber.Text.Length != 16) {
                MessageBox.Show("Credit card number must be 16 digits.");
                return;
            }
         

            estate.AddAdvertisement(new Advertisement(estate, DateTime.Now.Year + season));
            MainWindow.Instance.ChangeView("views/owner/AdvertiseEstateList.xaml");
        }

        private void ui_seasons_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter(ui_seasons, "[^1-9]");
        }

        private void ui_cardnumber_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter(ui_cardnumber, "[^0-9]");
        }

        private void ui_cardnumber_GotKeyboardFocus(object sender, RoutedEventArgs e) {
            if (string.Compare(ui_cardnumber.Text, "0000000000000000") == 0) {
                ui_cardnumber.Foreground = Brushes.Black;
                ui_cardnumber.Text = "";
            }
        }
    }
}
