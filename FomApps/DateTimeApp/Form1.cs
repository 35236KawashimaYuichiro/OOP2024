using System.Text.RegularExpressions;

namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            var today = DateTime.Today;

            TimeSpan diff = DateTime.Today - dtpDate.Value;
            tbDisp.Text = (diff.Days + 1) + "“ú–Ú";
        }



        private void “ú‘O_Click(object sender, EventArgs e) {
            var past = dtpDate.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = past.ToString();

        }

        private void “úŒã_Click(object sender, EventArgs e) {
            var past = dtpDate.Value.AddDays(+(double)nudDay.Value);
            tbDisp.Text = past.ToString();
        }

        private void btAge_Click(object sender, EventArgs e) {
            DateTime dt = dtpDate.Value;
            DateTime today = DateTime.Today;

            var age = today.Year - dt.Year;

            if (dt > today.AddYears(-age)) {
                age--;
            }
            tbDisp.Text = age.ToString() + "Î";
        }



    }
}
