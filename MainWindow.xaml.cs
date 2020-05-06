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

namespace EstateHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Main window is responsible for handling navigation calls, search requests and user changes (simulated login, logouts)
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get => App.Instance.MainWindow as MainWindow; }

        public MainWindow() {
            InitializeComponent();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e) {
            ChangeView("HomePage.xaml");
        }

        public void ChangeView(string view) {
            ui_mainView.Source = new Uri(view, UriKind.Relative);
        }

    }
}
