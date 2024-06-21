using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            var day = int.Parse(Console.ReadLine());

            DateTime bd = new DateTime(year, month, day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = bd.ToString("ggyy年M月d日dddd", culture);

            Console.WriteLine($"あなたは{str}に生まれました");

            TimeSpan diff = DateTime.Today - bd;
            Console.WriteLine("あなたは生まれてから、{0}日目です", diff.Days + 1);






        }

    }

}
