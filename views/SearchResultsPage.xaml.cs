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

namespace EstateHub.views
{
    /// <summary>
    /// Interaction logic for SearchResultsPage.xaml
    /// </summary>
    public partial class SearchResultsPage : Page
    {
        private SearchResults Search;
        public SearchResultsPage() {
            InitializeComponent();
        }

        public SearchResultsPage(SearchResults search) {
            Search = search;
            Search.Sort();
            InitializeComponent();

            Func<Estate, string> getTextForEstate = (Estate est) => {
                if (App.Instance.CurrentUser is Manager) {
                    return est.IsCurrentlyAvailable() ? "Make Offer" : "_Unavailable";
                }
                return ""; 
            };

            ui_adList.Children.Clear();
            foreach (var advEstate in search.AdvertisedEstatesToShow) {
                ui_adList.Children.Add(new EstateElementControl(advEstate, getTextForEstate(advEstate), OnEstateSelected));
            }
            if (ui_adList.Children.Count == 0) {
                ui_adContainer.Visibility = Visibility.Collapsed;
            }

            ui_resultsList.Children.Clear();
            foreach (var est in search.Estates) {
                ui_resultsList.Children.Add(new EstateElementControl(est, getTextForEstate(est), OnEstateSelected));
            }
        }

        public void OnEstateSelected(Estate estate) {
            estate.IncrementViewCount();

            var manager = App.GetCurrentManager();
            if (!(manager is null)) {
                manager.AddToHistory(estate);
            }
            
            MessageBox.Show(estate.Title);
            // TODO: Transition to show estate
        }
    }
}
