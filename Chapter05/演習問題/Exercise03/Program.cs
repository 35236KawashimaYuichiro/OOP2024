using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {

            text = "Jackdaws Love my big sphinx of quartz";
            int SpaceCount = text.Count(char.IsWhiteSpace);
            Console.WriteLine("空白の数: " + SpaceCount);
        }

        private static void Exercise3_2(string text) {

            string ok = text.Replace("big", "small");
            Console.WriteLine("置き換え後の文字列: " + ok);
        }

        private static void Exercise3_3(string text) {
            var str = new List<int>()text.Split(' ');
            var word = str.Count;
            Console.WriteLine(str);


        }

        private static void Exercise3_4(string text) {
            var str = text.Split(' ').Where(word => word.Length <= 4);
            foreach (var word in str) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
        }
    }
}
