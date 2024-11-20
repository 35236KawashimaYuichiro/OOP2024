using CustomerApp.Objects;
using SQLite;
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

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        private string _selectedImagePath;

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
        string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
        string.IsNullOrWhiteSpace(AddressTextBox.Text)) {
                MessageBox.Show("全てのフィールドを入力してください。");
                return;
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImagePath = _selectedImagePath // パスを保存
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }

            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            CustomerImage.Source = null;
            _selectedImagePath = null;

            ReadDatabase();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("更新するデータを選んでください。");
                return;
            }
            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;
            selectedCustomer.ImagePath = _selectedImagePath;

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
            }

            ReadDatabase();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

                CustomerListView.ItemsSource = _customers;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除するデータを選んで下さい");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);

                ReadDatabase();
            }


        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                if (!string.IsNullOrEmpty(selectedCustomer.ImagePath)) {
                    CustomerImage.Source = new BitmapImage(new Uri(selectedCustomer.ImagePath, UriKind.Absolute));
                } else {
                    CustomerImage.Source = null;
                }

            } else {
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                AddressTextBox.Clear();
                CustomerImage.Source = null;
            }
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "画像を選択してください"
            };

            if (openFileDialog.ShowDialog() == true) {
                string selectedFileName = openFileDialog.FileName;

                // ファイルパスを保存
                _selectedImagePath = null; // バイトデータは不要
                CustomerImage.Source = new BitmapImage(new Uri(selectedFileName, UriKind.Absolute));
                _selectedImagePath = selectedFileName; // パスを保存
            }
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("画像を削除する顧客を選んでください。");
                return;
            }

            selectedCustomer.ImagePath = null;

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
            }

            CustomerImage.Source = null;
            _selectedImagePath = null;
            MessageBox.Show("画像を削除しました。");

            ReadDatabase();

        }
    }
}
