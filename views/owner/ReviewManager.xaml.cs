using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ReviewManager.xaml
    /// </summary>
    public partial class ReviewManager : Page
    {
        private Manager manager;

        public ReviewManager(Manager inManager) {
            manager = inManager;
            InitializeComponent();
        }

        private void ui_submit_Click(object sender, RoutedEventArgs e) {
            int score;
            try {
                score = Int32.Parse(ui_score.Text);
            }
            catch {
                MessageBox.Show("Score must be a number between 1-5");
                return;
            }

            if (ui_comment.Text.Length > 160) {
                MessageBox.Show("Comment length must be less than 160 characters");
                return;
            }


            manager.AddReview(new Review() { Comment = ui_comment.Text, ForManager = manager, Stars = score, FromOwner = App.GetCurrentOwner() });
            MessageBox.Show("Review registered.");
            MainWindow.Instance.ChangeView("views/MainMenu.xaml");
        }

        private void TextboxRegexFilter(TextBox box, string regexPattern) {
            var cursorPosition = box.SelectionStart;
            box.Text = Regex.Replace(box.Text, regexPattern, "");
            box.SelectionStart = cursorPosition;
        }

        private void ui_score_TextChanged(object sender, TextChangedEventArgs e) {
            TextboxRegexFilter(ui_score, "[^1-5]");
        }
    }
}
