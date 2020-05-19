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
    public partial class EstateElementControl : UserControl
    {
        public delegate void OnEstateSelected(Estate estate);

        public OnEstateSelected SelectedCallback;
        public EstateElementControl(Estate estate, string btnText, OnEstateSelected callback) {
            InitializeComponent();
            DataContext = estate;
            if (string.IsNullOrEmpty(btnText)) {
                btn_button.Visibility = Visibility.Collapsed;
            }
            else if (btnText.StartsWith('_')){
                btn_button.IsEnabled = false;
                btn_Text.Text =  btnText.Substring(1);
                btn_Text.Foreground = Brushes.Black;
            }
            else {
                btn_Text.Text =  btnText;
                SelectedCallback = callback;
            }
        }


        public EstateElementControl() {
            InitializeComponent();
            DataContext = new Estate(null, new Location(55), "Ceid Estate");
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            if (!(SelectedCallback.Method is null)) {
                SelectedCallback((Estate)DataContext);
            }
            
        }
    }
}
