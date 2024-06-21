using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var bt1 = new DateTime(2004, 6, 19);
            //var bt2 = new DateTime(2004, 6, 1, 8, 45, 20);
            //Console.WriteLine(bt1);
            //Console.WriteLine(bt2);

            //var today =  DateTime.Today;
            //var now = DateTime.Now;
            //Console.WriteLine("Today:{0}",today);
            //Console.WriteLine("Now:{0}",now);

            //var isLeapYear = DateTime.IsLeapYear(2024);
            //if (isLeapYear) {
            //    Console.WriteLine("うるう年です");
            //} else {
            //    Console.WriteLine("うるう年ではありません");
            //}


            //DayOfWeek dayOfWeek = bt1.DayOfWeek;
            //if (dayOfWeek == DayOfWeek.Sunday)
            //    Console.WriteLine("あなたは日曜日に生まれました。");
            //if (dayOfWeek == DayOfWeek.Monday)
            //    Console.WriteLine("あなたは月曜日に生まれました。");
            //if (dayOfWeek == DayOfWeek.Tuesday)
            //    Console.WriteLine("あなたは火曜日に生まれました。");
            //if (dayOfWeek == DayOfWeek.Wednesday)
            //    Console.WriteLine("あなたは水曜日に生まれました。");
            //if (dayOfWeek == DayOfWeek.Thursday)
            //    Console.WriteLine("あなたは木曜日に生まれました。");
            //if (dayOfWeek == DayOfWeek.Friday)
            //    Console.WriteLine("あなたは金曜日に生まれました。");
            //if (dayOfWeek == DayOfWeek.Saturday)
            //    Console.WriteLine("あなたは土曜日に生まれました。");

            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            var year = int.Parse(Console.ReadLine());
            
            Console.Write("月:");
            var month = int.Parse(Console.ReadLine());

            Console.Write("日:");
            var day = int.Parse(Console.ReadLine());

            DateTime bt = new DateTime(year, month, day);

            DayOfWeek dayOfWeek = bt.DayOfWeek;

            string birthdayWeek = GetWeek(dayOfWeek);

            Console.WriteLine($"{year}年{month}月{day}日は{birthdayWeek}曜日です。");
        }

        static string GetWeek(DayOfWeek dayOfWeek) {
            switch (dayOfWeek) {
                case DayOfWeek.Sunday:
                    return "日";
                case DayOfWeek.Monday:
                    return "月";
                case DayOfWeek.Tuesday:
                    return "火";
                case DayOfWeek.Wednesday:
                    return "水";
                case DayOfWeek.Thursday:
                    return "木";
                case DayOfWeek.Friday:
                    return "金";
                case DayOfWeek.Saturday:
                    return "土";
                default:
                    throw new ArgumentException();
            }
        }

    }
    
}
