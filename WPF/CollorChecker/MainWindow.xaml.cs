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
        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //var value = (int)rSlider.Value;
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));

            rValue.Text = r.ToString();
            gValue.Text = g.ToString();
            bValue.Text = b.ToString();
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            if (stockList.Items.OfType<MyColor>().Any(c => c.Color.Equals(Color.FromRgb(r, g, b)))) {
                MessageBox.Show("この色はすでに保存されています。");
                return;
            }
            MyColor newColor = new MyColor {
                Color = Color.FromRgb(r, g, b),
                Name = $"Color {stockList.Items.Count + 1}"
            };

            stockList.Items.Insert(0, newColor);
        }
    

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                colorArea.Background = new SolidColorBrush(selectedColor.Color);

                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;

                rValue.Text = selectedColor.Color.R.ToString();
                gValue.Text = selectedColor.Color.G.ToString();
                bValue.Text = selectedColor.Color.B.ToString();
            }
        }
    }
}
