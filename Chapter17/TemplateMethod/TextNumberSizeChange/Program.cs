using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace TextNumberSizeChange {
    internal class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("テキストファイルのパスを指定してください。");
                return;
            }
            TextProcessor.Run<ToHankakuProcessor>(args[0]);
        }
    }
}
