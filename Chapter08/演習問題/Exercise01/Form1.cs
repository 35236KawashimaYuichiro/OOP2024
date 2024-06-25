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
            tbDisp.Text += dt1.ToString("yyyy”NMMŒŽdd“ú HHŽžmm•ªss•b") + "\r\n";
            tbDisp.Text += dt1.ToString("ggyy”NMŒŽd“ú(dddd)", culture) + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            DateTime nextWeekDay = NextDay(today,DayOfWeek.Tuesday);

            tbDisp2.Text = nextWeekDay.ToString("d");
        }

        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0) 
                days += 7;
                return date.AddDays(days);
        }

    }
}
