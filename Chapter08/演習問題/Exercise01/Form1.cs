using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {

            var dt1 = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            tbDisp.Text = dt1.ToString("d") + dt1.ToString("t") + "\r\n";
            tbDisp.Text += dt1.ToString("yyyy年MM月dd日 HH時mm分ss秒") + "\r\n";
            tbDisp.Text += dt1.ToString("ggyy年M月d日(dddd)", culture) + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {

        }
    }
}
