using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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

            currentColor.Color = Color.FromArgb(255, 0, 0, 0);

            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(currentColor.Color);

            //colorSelectComboBox.SelectedItem = null;
            var matchedColor = ((MyColor[])DataContext).FirstOrDefault(c => c.Color == currentColor.Color);
            currentColor.Name = matchedColor.Name ?? $"R: {currentColor.Color.R}, G: {currentColor.Color.G}, B: {currentColor.Color.B}";
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var colorName = currentColor.Name ?? $"{currentColor.Color}";
            var colorExists = stockList.Items.OfType<MyColor>().Any(color => color.Color == currentColor.Color);

            if (!colorExists) {
                stockList.Items.Insert(0, new MyColor { Color = currentColor.Color, Name = colorName });
            } else {
                MessageBox.Show("この色は追加済です。");
            }
        }


        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedIndex != -1) { // 有効なインデックスか確認
                var selectedColor = (MyColor)stockList.SelectedItem;
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                setSliderValue(selectedColor.Color);
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            currentColor = (MyColor)((ComboBox)sender).SelectedItem;
            setSliderValue(currentColor.Color);
            colorArea.Background = new SolidColorBrush(currentColor.Color);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            if (stockList.SelectedItem != null) {
                stockList.Items.Remove(stockList.SelectedItem);

                colorArea.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                rSlider.Value = 0;
                gSlider.Value = 0;
                bSlider.Value = 0;
            } else {
                MessageBox.Show("削除する色を選択してください。"); 
            }
        }
    }
}
 
