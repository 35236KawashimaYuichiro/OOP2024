using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            var text2 = "Jackdaws,love my,big sphinx-of_quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            Console.WriteLine("-----");

            Exercise3_6(text2);
            Console.WriteLine("-----");
        }

        private static void Exercise3_1(string text) {
            int SpaceCount = text.Count(c => c == ' ');
            Console.WriteLine("空白の数: " + SpaceCount);
        }

        private static void Exercise3_2(string text) {
            string ok = text.Replace("big", "small");
            Console.WriteLine("置き換え後の文字列: " + ok);
        }

        private static void Exercise3_3(string text) {
            var str = text.Split(' ').Length;
            Console.WriteLine("単語数：" + str);

        }

        private static void Exercise3_4(string text) {
            var str = text.Split(' ').Where(word => word.Length <= 4);
            Console.WriteLine("4文字以下の単語");
            foreach (var word in str) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var str = text.Split(' ').ToArray();
            var ss = new StringBuilder();
            foreach (string word in str) {
                ss.Append(word).Append(' ');
            }
            Console.WriteLine(ss);
        }

        private static void Exercise3_6(string text2) {
            var str = text2.Split(' ',',','-','_').Where(word => word.Length <= 4);
            Console.WriteLine("4文字以下の単語");
            foreach (var word in str) {
                Console.WriteLine(word);
            }
        }
    }
}