﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            //7.2.3(Countの呼び出し)
            Console.WriteLine("略語辞書の用語の数：" + abbrs.Count);


            //7.2.3(Removeの呼び出し)
            if (abbrs.Remove("NPT"))
                Console.WriteLine("削除後の略語辞書の用語の数：" + abbrs.Count);
            else
                Console.WriteLine("削除出来ません");

            //7.2.4
            Console.WriteLine("3文字の省略語：");
            foreach (var abbr in  abbrs.Where(x => x.Key.Length == 3)) {
                Console.WriteLine(abbr);
            }



            Console.WriteLine();

            // インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names) {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}は見つかりません", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0} は見つかりません", japanese);
            else
                Console.WriteLine("「{0}」の略語は {1} です", japanese, abbreviation);
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach (var item in abbrs.FindAll("国際")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();


        }
    }
}
