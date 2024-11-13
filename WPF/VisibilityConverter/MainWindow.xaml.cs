using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace VisibilityConverter {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        //private void Button_Click(object sender, RoutedEventArgs e) {
        //    Resources["ButtonBrushKey"] = new SolidColorBrush(Colors.DarkSeaGreen);
        //}
        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            if (sender is RadioButton radioButton) {
                string color = radioButton.Tag.ToString();
                SolidColorBrush newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
                Resources["ButtonBrushKey"] = newBrush;
            }
        }
    }
}