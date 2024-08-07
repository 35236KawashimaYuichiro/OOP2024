using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {

        Settings settings = Settings.getInstance(); // 設定ファイルのインスタンス

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;

        }

        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            CarReport carReport = new CarReport {
                Date = dtpdate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);

            dgvCarReport.ClearSelection();  //セレクションを外す
            inputItemsAllClear();   //入力項目をすべてクリア
        }
        //入力項目をすべてクリア
        private void inputItemsAllClear() {
            dtpdate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }
        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbInport.Checked)
                return CarReport.MakerGroup.輸入車;
            if (rb.Checked)
                return CarReport.MakerGroup.その他;

            return CarReport.MakerGroup.その他;
        }
        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.なし:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbInport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rb.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbInport.Checked = false;
            rb.Checked = false;
        }

        //画像選択
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //画像削除ボタン
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;  //画像表示しない

            //交互に色を設定
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //逆シリアル化
            try {
                if (File.Exists("settings.xml")) {
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        // 設定を反映
                        this.BackColor = Color.FromArgb(settings.MainFormColor);
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("設定ファイルの読み込みエラー");
            }


        }

        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            dtpdate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;

            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);

            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;

            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;
        }

        //削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();  //セレクションを外す
            //dgvCarReport.CurrentRow = null;
        }

        //修正ボタン
        private void btModifyReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpdate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

            dgvCarReport.Refresh(); //データグリッドビューの更新
        }

        //記録者のテキストが編集されたら
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
        //車名のテキストが編集されたら
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        // 保存ボタン
        private void btReportSave_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                                        sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {

                    throw;
                }
            }
        }

        private void btReportOpen_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        private void ReportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                                        ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "ファイル形式が違います";

                }
                dgvCarReport.ClearSelection();

                foreach (CarReport report in listCarReports) {
                    setCbAuthor(report.Author);
                    setCbCarName(report.CarName);
                }
            }
        }

        private void btClear_Click(object sender, EventArgs e) {
            inputItemsAllClear();
            dgvCarReport.ClearSelection();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            // 終了確認のメッセージボックスを表示
            if (MessageBox.Show("アプリケーションを終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("設定ファイルの読み込みエラー");
            }
        }

        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e) {
            var fmversion = new fmVersion();
            fmversion.ShowDialog();
        }
    }


}
