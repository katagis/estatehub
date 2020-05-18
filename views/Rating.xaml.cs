﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace EstateHub.views
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Rating", typeof(int), typeof(Rating),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RatingChanged)));

        private readonly int _max = 5;
        private bool editable = false;
        public int Value {
            get {
                return (int)GetValue(ValueProperty);
            }
            set {
                if (value < 0) {
                    SetValue(ValueProperty, 0);
                }
                else if (value > _max) {
                    SetValue(ValueProperty, _max);
                }
                else {
                    SetValue(ValueProperty, value);
                }
            }
        }

        private static void RatingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            Rating item = sender as Rating;
            int newval = (int)e.NewValue;
            UIElementCollection childs = ((Grid)item.Content).Children;

            ToggleButton button = null;

            for (int i = 0; i<newval; i++) {
                button = childs [i] as ToggleButton;
                if (button!=null)
                    button.IsChecked = true;
            }

            for (int i = newval; i<childs.Count; i++) {
                button = childs [i] as ToggleButton;
                if (button!=null)
                    button.IsChecked = false;
            }

        }

        private void ClickEventHandler(object sender, RoutedEventArgs args) {
            if (!editable) {
                return;
            }
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            Value = newvalue;
        }

        public Rating() {
            InitializeComponent();
        }
    }
}
