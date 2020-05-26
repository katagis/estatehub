using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu() {
            InitializeComponent();
            ReloadForCurrentUser();
        }

        public void ReloadForCurrentUser() {
            Notification notifToShow = null;
            var notifList = App.Instance.CurrentUser.Notifications;
            
            if (notifList.Count > 0) {
                notifToShow = notifList [0];
                notifList.RemoveAt(0);
            }            

            if (App.Instance.CurrentUser is Owner) {
                InitializeMenuList(MainWindow.navViews_Owner, notifToShow);
            }
            else {
                InitializeMenuList(MainWindow.navViews_Manager, notifToShow);
            }
        }

        private void InitializeMenuList(List<(string Title, string ViewPath)> list, Notification notification) {
            // <Button x:Name="button" Grid.Row="1" Grid.Column="1" Margin="5,5,5,5" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Background="#FF798093" BorderThickness="0">
            //    <TextBlock x:Name="textBlock" Foreground="White" Text="Submit Estate"/>
            //</Button>
            Func<string, string, int, Button> buildButton = (string name, string view, int row) => {
                var btn = new Button {
                    Content = name,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = new SolidColorBrush(Color.FromRgb(0x79, 0x80, 0x93)),
                    Foreground = new SolidColorBrush(Colors.White),
                    BorderThickness = new Thickness(0),
                    FontSize = 16,
                };
                btn.Click += (_1, _2) => { MainWindow.Instance.ChangeView(view); };
                btn.SetValue(Grid.RowProperty, row);
                btn.SetValue(Grid.ColumnProperty, 1);
                return btn;
            };


            var notificationElem = ui_contentGrid.Children[0];
            ui_contentGrid.Children.Clear();

            int row = 1;

            if (notification is null) {
                ui_contentGrid.RowDefinitions.RemoveAt(0);
                row = 0;
            }
            else {
                ui_contentGrid.Children.Add(notificationElem);
                ui_notificationTxt.Text =  notification.Text;
                row = 1;
            }

            foreach (var view in list) {
                ui_contentGrid.Children.Add(buildButton(view.Title, view.ViewPath, row++));
            }
        }
    }
}
