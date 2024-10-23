﻿using System;
using System.Collections.Generic;
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

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //var value = (int)rSlider.Value;
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            MyColor myColor = new MyColor {
                Color = Color.FromRgb(r, g, b),
                Name = $"R: {r}, G: {g}, B: {b}"
            };
            bool exists = stockList.Items.Cast<MyColor>().Any(c => c.Color == myColor.Color);
            if (!exists) {
                stockList.Items.Add(myColor);
            } else {
                MessageBox.Show("この色はすでにリストに存在します。", "重複エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
            }
        }
    }
}
