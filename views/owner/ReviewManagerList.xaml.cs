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

namespace EstateHub.views.owner
{
    /// <summary>
    /// Interaction logic for ReviewManagerList.xaml
    /// </summary>
    public partial class ReviewManagerList : Page
    {
        public ReviewManagerList() {
            InitializeComponent();
            var owner = App.GetCurrentOwner();

            ui_managerList.Children.Clear();


            HashSet<Manager> availManagers = new HashSet<Manager>();

            foreach (var estate in owner.Estates) {
                if (!(estate.CurrentDeal is null)) {
                    var manager = estate.CurrentDeal.Offerer;
                    availManagers.Add(manager);
                }
            }

            if (availManagers.Count == 0) {
                MessageBox.Show("No managers available for review found.");
                MainWindow.Instance.ChangeView("views/MainMenu.xaml");
                return;
            }

            foreach (var man in availManagers) {
                ui_managerList.Children.Add(new ManagerElementControl(man, "Rate Manager", OnSelect));
            }

        }

        public void OnSelect(Manager man, Offer offer) {
            var owner = App.GetCurrentOwner();
            var oldReview = man.GetReviewFrom(owner);
            
            if (!(oldReview is null)) {
                if (MessageBoxResult.No == MessageBox.Show("You already have a review for " + man.Username + ".\nDo you want to overwrite it?", "", MessageBoxButton.YesNo)) {
                    return;
                }
            }

            MainWindow.Instance.ChangeView(new ReviewManager(man));
        }
    }
}
