using System;
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
        MyColor currentColor;

        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(currentColor.Color);
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            if (!stockList.Items.OfType<MyColor>().Any(color => color.Color == currentColor.Color)) {
                stockList.Items.Insert(0, currentColor);
            } else {
                MessageBox.Show("この色はすでに保存されています。");
            }
        }


        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            colorArea. Background = new SolidColorBrush(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            rSlider.Value = ((MyColor)stockList.Items[stockList.SelectedIndex]).Color.R;
            gSlider.Value = ((MyColor)stockList.Items[stockList.SelectedIndex]).Color.G;
            bSlider.Value = ((MyColor)stockList.Items[stockList.SelectedIndex]).Color.B;
        }
    }
}