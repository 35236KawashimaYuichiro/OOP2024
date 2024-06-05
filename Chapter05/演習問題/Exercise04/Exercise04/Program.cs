using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            {
                var line = "Novelist=谷崎潤一郎：BestWork=春琴抄：Born=1886";

                // 文字列を':'で分割
                string[] str = line.Split('：');

                foreach (var word in str) {
                    // '='で分割
                    string[] keyValue = word.Split('=');
                    string key = keyValue[0];
                    string value = keyValue[1];
                    string Japanese = ToJapanese(key);

                    Console.WriteLine($"{Japanese}：{value}");
                }
            }
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
            }
            throw new ArgumentException("引数に誤りがあります");
        }
    }
}