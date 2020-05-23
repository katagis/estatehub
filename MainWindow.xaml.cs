using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using EstateHub.views;

namespace EstateHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Main window is responsible for handling navigation calls, search requests and user changes (simulated login, logouts)
    public partial class MainWindow : Window {
        public static MainWindow Instance { get => App.Instance.MainWindow as MainWindow; }

        private static readonly string defaultSearchTxt = "Search for estates, places...";

        // A bit ugly requires up-cast
        public static readonly List<(string Title, string ViewPath)> navViews_Owner = new List<(string, string)>{
                ("Register Estate", "views/owner/RegisterEstateView.xaml"),
                ("View Offers"    , "views/owner/ViewAcceptOffer.xaml"),
                ("Advertise Estate"     , "views/owner/AdvertiseEstateList.xaml"),
        };

        public static readonly List<(string Title, string ViewPath)> navViews_Manager = new List<(string, string)>{
                ("Search for Estates"   , "views/SearchResultsPage.xaml"),
                ("Pending Offers"       , "views/manager/PendingOffersView.xaml"),
        };

        private bool isRedirecting = false;
        private string nextRedirectionView = "";

        private SearchResults lastSearch;

        public MainWindow() {
            var defaultUser = App.Instance.CurrentUser;
            InitializeComponent();
            ui_search.Text = defaultSearchTxt;
            ui_search.GotFocus += Ui_search_GotFocus;
            ui_search.LostFocus += Ui_search_LostFocus;
            ui_userCombo.ItemsSource = Estatehub.Users;
            ui_userCombo.SelectedItem = defaultUser;
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e) {
            ChangeView("views/MainMenu.xaml");
        }

        public void ChangeView(string view) {
            if (isRedirecting) {
                nextRedirectionView = view;
                return;
            }
            
            isRedirecting = true;
            // Explicitly reload the component of the view to "refresh" the page
            Uri resource = new Uri(view, UriKind.Relative);
            try {
                ui_mainView.Content = Application.LoadComponent(resource);
            }
            catch {
                MessageBox.Show("View not found: " + view);
            }
            isRedirecting = false;

            if (!string.IsNullOrWhiteSpace(nextRedirectionView)) {
                var redirection = nextRedirectionView;
                nextRedirectionView = "";
                ChangeView(redirection);
            }
        }

        public void ChangeView(Page page) {
            ui_mainView.Content = page;
        }

        private void UpdateNavFromList(List<(string Title, string ViewPath)> navViewList) {
            Func<string, string, Button> buildButton = (string name, string view) => {
                var btn = new Button {
                    Content = name,
                    Foreground = new SolidColorBrush(Color.FromRgb(0x60, 0x67, 0x71)),
                    BorderThickness = new Thickness(0, 0, 1, 0),
                    FontSize = 16,
                    Padding = new Thickness(10, 1, 10, 1),
                    Height = 35,
                };
                btn.Click += (_1, _2) => { Instance.ChangeView(view); }; 
                return btn;
            };

            ui_navbar.Children.Clear();
            foreach (var v in navViewList) {
                ui_navbar.Children.Add(buildButton(v.Title, v.ViewPath));
            }

            (ui_navbar.Children[^1] as Button).BorderThickness = new Thickness(0);
        }

        public void InitializeForUser(User user) {
            if (user is Owner) {
                UpdateNavFromList(navViews_Owner);
            }
            else {
                UpdateNavFromList(navViews_Manager);
            }
            ChangeView("views/MainMenu.xaml");
        }
        

        //
        // Search bar controller
        //
        public void PerformSearch(string term, bool includeUnavailable) {
            lastSearch  = Estatehub.Search(term, includeUnavailable);
            if (lastSearch.IsEmpty()) {
                MessageBox.Show("No results found for search: " + term);
            }
            else {
                ChangeView(new SearchResultsPage(lastSearch));
            }
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
                bool unavail = ui_searchUnavailable.IsChecked is null ? false : (bool)ui_searchUnavailable.IsChecked;
                PerformSearch(ui_search.Text.Trim(), unavail);
            }
        }

        private void Ui_userCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            App.Instance.ChangeUser(ui_userCombo.SelectedItem as User);
        }
    }
}
