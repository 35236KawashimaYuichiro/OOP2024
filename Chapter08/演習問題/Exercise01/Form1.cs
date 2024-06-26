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
            tbDisp.Text += dt1.ToString("yyyy”NMMŒdd“ú HHmm•ªss•b") + "\r\n";
            tbDisp.Text += dt1.ToString("ggyy”NMŒd“ú(dddd)", culture) + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            DateTime date = DateTime.Today;
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                var str1 = string.Format("{0:yy/MM/dd}‚ÌŸT‚Ì{1}:", date, dayOfWeek);
                var str2 = string.Format("{0:yy/MM/dd(ddd)}", NextDay(date, dayOfWeek));
                tbDisp.Text += str1 + str2 + "\r\n";
            }
        }

        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var days = (int)dayOfWeek - (int)date.DayOfWeek;
            return date.AddDays(days);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = string.Format("ˆ—ŠÔ‚Í{0}ƒ~ƒŠ•b‚Å‚µ‚½",duration.TotalMilliseconds);
            tbDisp3.Text = str;
        }
    }

    class TimeWatch {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time; 
        }

    }
}
