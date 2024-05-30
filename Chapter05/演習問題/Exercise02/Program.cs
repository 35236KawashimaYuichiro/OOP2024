using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("数字文字列を入力:");
            string num = Console.ReadLine();

            if (int.TryParse(num, out int number)) {
                Console.WriteLine("{0:#,#}", number);
            } else {
                Console.WriteLine("無効な文字列です");
            }
        }
    }
}
