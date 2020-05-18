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
    /// Interaction logic for EstateElementControl.xaml
    /// </summary>
    public partial class ManagerElementControl : UserControl
    {
        public delegate void OnManagerSelected(Manager estate);

        public OnManagerSelected SelectedCallback;
        public ManagerElementControl(Manager manager, string btnText, OnManagerSelected callback) {
            InitializeComponent();
            DataContext = manager;
            btn_Text.Text =  btnText;
            SelectedCallback = callback;
        }

        public ManagerElementControl() {
            InitializeComponent();
            DataContext = new Estate();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SelectedCallback((Manager)DataContext);
        }
    }
}
