using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            {
                var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

                // 文字列を';'で分割
                string[] str = line.Split(';');

                foreach (var word in line.Split(';')) {
                    // '='で分割
                    var array = word.Split('=');
                    Console.WriteLine("{0}：{1}", ToJapanese(array[0]), array[1]);
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