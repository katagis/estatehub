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

        public CreateOffer(Estate inEstate) {
            estate = inEstate;
            DataContext = estate;
            InitializeComponent();
            ui_title.Text = "Make an offer for " + estate.Title + ":";
        }

        private void TextboxRegexFilter(TextBox box, string regexPattern) {
            var cursorPosition = box.SelectionStart;
            box.Text = Regex.Replace(box.Text, regexPattern, "");
            box.SelectionStart = cursorPosition;
        }

        private void ui_submit_Click(object sender, RoutedEventArgs e) {
            int amount; 
            int seasons;


            try {
                amount = Int32.Parse(ui_amount.Text);
                if (amount <= 0) {
                    MessageBox.Show("Amount field must be positive.");
                    return;
                }
            }
            catch {
                MessageBox.Show("Amount field must be a number.");
                return;
            }

            try {
                seasons = Int32.Parse(ui_seasons.Text);
                if (seasons <= 0) {
                    MessageBox.Show("Seasons field must be positive.");
                    return;
                }
            }
            catch {
                MessageBox.Show("Seasons field must be a number.");
                return;
            }

            var manager = App.GetCurrentManager();
            var prevOffer = estate.GetCurrentOfferFrom(manager);
            if (!(prevOffer is null)) {
                if (MessageBox.Show("You already have an offer for " + estate.Title +".\nDo you want to replace it?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                    // User selected to replace offer
                    estate.ActiveOffers.Remove(prevOffer);
                    manager.Offers.Remove(prevOffer);
                }
                else {
                    MainWindow.Instance.ChangeView("views/MainMenu.xaml");
                    return;
                }
            }


            Offer offer = new Offer() { Offerer = manager, Estate = estate, EndingSeason = seasons +  DateTime.Now.Year, Money = amount };
            estate.ActiveOffers.Add(offer);
            estate.Owner.RegisterNotification(new Notification(estate.Owner, "You have a new offer for " + estate.Title));
            manager.Offers.Add(offer);

            MessageBox.Show("Offer registered for " + estate.Title, "", MessageBoxButton.OK);
            MainWindow.Instance.ChangeView("views/MainMenu.xaml");
        }

        private void ui_seasons_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter((TextBox)sender, "[^1-9]");
        }

        private void ui_amount_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter((TextBox)sender, "(^0|[^0-9])");
        }
    }
}
