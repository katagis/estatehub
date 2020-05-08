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
        public SelectionPage()
        {
            InitializeComponent();
        }

        private void butto2n_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).ChangeView("Selection2.xaml");
            
        }
    }
}
