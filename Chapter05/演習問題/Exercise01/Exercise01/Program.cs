using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("文字列1を入力:");
            string str1 = Console.ReadLine();

            Console.WriteLine("文字列2を入力:");
            string str2 = Console.ReadLine();

            if (str1.Equals(str2, StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("入力された文字列は等しい");
            } else {
                Console.WriteLine("入力された文字列は等しくない");
            }
        }

    }
}
