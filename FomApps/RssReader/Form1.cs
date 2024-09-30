using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.Core;

namespace RssReader {
    public partial class Form1 : Form {
        List<ItemData> items;
        private List<CategoryUrlPair> categoryUrlPairs;
        private List<CategoryUrlPair> defaultCategories;

        public Form1() {
            InitializeComponent();
            InitializeWebView2Async();
            InitializeCategoryUrlPairs();
        }

        private void InitializeCategoryUrlPairs() {
            defaultCategories = new List<CategoryUrlPair>
            {
                new CategoryUrlPair("主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"),
                new CategoryUrlPair("国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"),
                new CategoryUrlPair("国際", "https://news.yahoo.co.jp/rss/topics/world.xml"),
                new CategoryUrlPair("経済", "https://news.yahoo.co.jp/rss/topics/business.xml"),
                new CategoryUrlPair("エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"),
                new CategoryUrlPair("スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"),
                new CategoryUrlPair("IT", "https://news.yahoo.co.jp/rss/topics/it.xml"),
                new CategoryUrlPair("科学", "https://news.yahoo.co.jp/rss/topics/science.xml"),
                new CategoryUrlPair("地域", "https://news.yahoo.co.jp/rss/topics/local.xml"),
            };

            categoryUrlPairs = new List<CategoryUrlPair>(defaultCategories);

            comboBox1.DataSource = categoryUrlPairs;
            comboBox1.DisplayMember = "Category";
            comboBox1.ValueMember = "Url";
        }

        private async void InitializeWebView2Async() {
            try {
                await webView2.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex) {
                MessageBox.Show($"WebView2の初期化中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btGet_Click(object sender, EventArgs e) {
            lbRssTitle.Items.Clear();
            try {
                if (comboBox1.SelectedValue is string url && !string.IsNullOrWhiteSpace(url)) {
                    using (var httpClient = new HttpClient()) {
                        var response = await httpClient.GetStringAsync(url);
                        var xdoc = XDocument.Parse(response);
                        items = xdoc.Root.Descendants("item")
                                         .Select(item => new ItemData {
                                             Title = item.Element("title")?.Value,
                                             Link = item.Element("link")?.Value,
                                         }).ToList();

                        foreach (var item in items) {
                            lbRssTitle.Items.Add(item.Title);
                        }
                    }
                } else {
                    MessageBox.Show("URLが選択されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex >= 0 && lbRssTitle.SelectedIndex < items.Count) {
                var selectedItem = items[lbRssTitle.SelectedIndex];
                if (!string.IsNullOrEmpty(selectedItem.Link) && webView2.CoreWebView2 != null) {
                    webView2.CoreWebView2.Navigate(selectedItem.Link);
                }
            }
        }

        private void Registration(object sender, EventArgs e) {
            string categoryName = textBox1.Text;
            string url = comboBox1.Text;

            if (string.IsNullOrWhiteSpace(categoryName)) {
                MessageBox.Show("カテゴリ名を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(url)) {
                MessageBox.Show("URLを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newPair = new CategoryUrlPair(categoryName, url);
            categoryUrlPairs.Add(newPair);

            comboBox1.DataSource = null;
            comboBox1.DataSource = categoryUrlPairs;
            comboBox1.DisplayMember = "Category";
            comboBox1.ValueMember = "Url";

            textBox1.Text = "";

            MessageBox.Show("登録しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btDelete_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedItem is CategoryUrlPair selectedPair) {
                if (defaultCategories.Any(c => c.Category == selectedPair.Category && c.Url == selectedPair.Url)) {
                    MessageBox.Show("デフォルトの項目は削除できません。", "削除エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                categoryUrlPairs.Remove(selectedPair);

                comboBox1.DataSource = null;
                comboBox1.DataSource = categoryUrlPairs;
                comboBox1.DisplayMember = "Category";
                comboBox1.ValueMember = "Url";

                MessageBox.Show("削除しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show("削除するアイテムを選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (items == null || !items.Any()) return;

            var searchText = textBox2.Text.ToLower();
            var filteredItems = items
                                .Where(item => item.Title.ToLower().Contains(searchText))
                                .ToList();

            lbRssTitle.Items.Clear();
            foreach (var item in filteredItems) {
                lbRssTitle.Items.Add(item.Title);
            }

            if (!filteredItems.Any()) {
                lbRssTitle.Items.Add("該当する記事がありません");
                MessageBox.Show("該当する結果がありませんでした。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

// データ格納用のクラス
public class ItemData {
    public string Title { get; set; }
    public string Link { get; set; }
}

public class CategoryUrlPair {
    public string Category { get; set; }
    public string Url { get; set; }

    public CategoryUrlPair(string category, string url) {
        Category = category;
        Url = url;
    }
}