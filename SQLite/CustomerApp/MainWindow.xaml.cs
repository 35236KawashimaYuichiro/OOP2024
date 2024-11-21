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
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)) {
                MessageBox.Show("名前を入力してください。");
                return;
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text
            };

            if (_selectedImagePath != null) {
                customer.SetImageFromFile(_selectedImagePath);
            }

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

            if (_selectedImagePath != null) {
                selectedCustomer.SetImageFromFile(_selectedImagePath);
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
                MessageBox.Show("データを更新しました。");
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

                if (selectedCustomer.ImageSource != null) {
                    CustomerImage.Source = selectedCustomer.ImageSource;
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
                _selectedImagePath = selectedFileName;
                CustomerImage.Source = new BitmapImage(new Uri(selectedFileName, UriKind.Absolute));
            }
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("画像を削除する顧客を選んでください。");
                return;
            }
            selectedCustomer.ClearImage();
            CustomerImage.Source = null;
            _selectedImagePath = null;
            MessageBox.Show("画像を削除しました。");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e) {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            CustomerImage.Source = null;
            _selectedImagePath = null;
            CustomerListView.SelectedItem = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase();
        }
    }
}
