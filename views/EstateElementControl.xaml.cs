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
            btn_Text.Text =  btnText;
            SelectedCallback = callback;
        }

        public EstateElementControl() {
            InitializeComponent();
            DataContext = new Estate();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SelectedCallback((Estate)DataContext);
        }
    }
}
