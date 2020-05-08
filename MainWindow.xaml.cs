using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace EstateHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Main window is responsible for handling navigation calls, search requests and user changes (simulated login, logouts)
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get => App.Instance.MainWindow as MainWindow; }

        private static readonly string defaultSearchTxt = "Search for estates, places...";
        public MainWindow() {
            InitializeComponent();
            ui_search.Text = defaultSearchTxt;
            ui_search.GotFocus += Ui_search_GotFocus;
            ui_search.LostFocus += Ui_search_LostFocus;
            ui_userCombo.ItemsSource = Database.Users;
            InitializeForUser(App.Instance.CurrentUser);
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e) {
            ChangeView("views/RegisterEstateView.xaml");
        }

        public void ChangeView(string view) {
            ui_mainView.Source = new Uri(view, UriKind.Relative);
        }

        private void InitializeForUser(User user) {

        }

        //
        // Search bar controller
        //
        public void PerformSearch(string term) {
            // TODO: perform search
            MessageBox.Show("Searching for: " + term);
        }


        //
        // Search bar View Section
        //
        private void Ui_search_GotFocus(object sender, RoutedEventArgs e) {
            if (ui_search.Text == defaultSearchTxt) {
                ui_search.Text = "";
                ui_search.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Ui_search_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(ui_search.Text)) {
                ui_search.Text = defaultSearchTxt;
                ui_search.Foreground = new SolidColorBrush(Colors.LightSlateGray);
            }
        }

        private void Ui_search_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                PerformSearch(ui_search.Text.Trim());
            }
        }

        private void Ui_userCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            App.Instance.ChangeUser(ui_userCombo.SelectedItem as User);
        }
    }
}
