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

namespace GridSample {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            checkBoxTextBlook.Text = "チェック済";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            checkBoxTextBlook.Text = "未チェック";
        }

        private void BlueRadioButton_Checked(object sender, RoutedEventArgs e) {
            checkBoxTextBlook.Text = "青";
        }

        private void YellowRadioButton_Checked(object sender, RoutedEventArgs e) {
            checkBoxTextBlook.Text = "黄";
        }

        private void RedRadioButton_Checked(object sender, RoutedEventArgs e) {
            checkBoxTextBlook.Text = "赤";
        }

        private void SeasonComboBox_SelectionChanged(object sender, RoutedEventArgs e) {
            seasonTextBlook.Text = (string)((ComboBoxItem)seasonComboBox.SelectedItem).Content;
        }
    }
}
