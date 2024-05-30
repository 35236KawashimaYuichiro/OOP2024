using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            string[] parts = line.Split(';');

            string novelist = parts[0].Split('=')[1];
            string bestWork = parts[1].Split('=')[1];
            string birthYear = parts[2].Split('=')[1];

            Console.WriteLine("作家：" + novelist);
            Console.WriteLine("代表作：" + bestWork);
            Console.WriteLine("誕生年：" + birthYear);

        }

        //できたら以下のメソッドを完成させて利用する
        //static string ToJapanese(string key) {


        //}
    }
}
