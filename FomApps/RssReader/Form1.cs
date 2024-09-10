using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.Core;

namespace RssReader {
    public partial class Form1 : Form {
        List<ItemData> items;
        private List<CategoryUrlPair> categoryUrlPairs;

        public Form1() {
            InitializeComponent();
            InitializeWebView2Async();
            InitializeCategoryUrlPairs(); // カテゴリとURLの初期化を追加
        }

        // カテゴリとURLのペアを初期化
        private void InitializeCategoryUrlPairs() {
            categoryUrlPairs = new List<CategoryUrlPair>
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

            comboBox1.DataSource = categoryUrlPairs;
            comboBox1.DisplayMember = "Category";
            comboBox1.ValueMember = "Url";
        }

        // WebView2の初期化
        private async void InitializeWebView2Async() {
            await webView2.EnsureCoreWebView2Async(null);
        }

        // RSSフィードの取得
        private void btGet_Click(object sender, EventArgs e) {
            lbRssTitle.Items.Clear(); // リストをクリア
            using (var wc = new WebClient()) {
                try {
                    var url = comboBox1.SelectedValue.ToString(); // 選択されたURLを取得
                    var xdoc = XDocument.Load(url);

                    // RSSアイテムを取得して、itemsリストに格納
                    items = xdoc.Root.Descendants("item")
                                     .Select(item => new ItemData {
                                         Title = item.Element("title")?.Value,
                                         Link = item.Element("link")?.Value,
                                     }).ToList();

                    // タイトルをリストボックスに追加
                    foreach (var item in items) {
                        lbRssTitle.Items.Add(item.Title);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                }
            }
        }

        // リストボックスで選択されたアイテムを表示
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex >= 0 && lbRssTitle.SelectedIndex < items.Count) {
                var selectedItem = items[lbRssTitle.SelectedIndex];
                if (!string.IsNullOrEmpty(selectedItem.Link) && webView2.CoreWebView2 != null) {
                    webView2.CoreWebView2.Navigate(selectedItem.Link);
                }
            }
        }

        // 新しいカテゴリとURLを登録
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
            comboBox1.Text = "";

            MessageBox.Show("登録しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // データ格納用のクラス
    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }

    // カテゴリとURLをペアで格納するクラス
    public class CategoryUrlPair {
        public string Category { get; set; }
        public string Url { get; set; }

        public CategoryUrlPair(string category, string url) {
            Category = category;
            Url = url;
        }

       
    }
}
