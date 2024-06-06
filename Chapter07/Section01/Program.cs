using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var employeeDict = new Dictionary<int, Employee> {
            //   { 100, new Employee(100, "清水遼久") },
            //   { 112, new Employee(112, "芹沢洋和") },
            //   { 125, new Employee(125, "岩瀬奈央子") },
            //};

            //employeeDict.Add(126, new Employee(126, "おい"));


            //foreach( var item in employeeDict.Keys) {
            //    Console.WriteLine($"{item} {item}");
            //}

            // 都道府県をキー、県庁所在地を値とするDictionaryの初期化
            Dictionary<string, string> ken = new Dictionary<string, string>();



            for (int i = 0; i < 5; i++) {

                Console.WriteLine("都道府県:");
                string str1 = Console.ReadLine();
                Console.WriteLine("県庁所在地:");
                string str2 = Console.ReadLine();

                if (!ken.ContainsKey(str1)) {
                    ken[str1] = str2;
                } else {
                    Console.WriteLine($"{str1}は既に登録されています。上書きしますか？");
                    Console.WriteLine("上書きする場合は：１, しない場合は２");
                    var m = Console.ReadLine();
                    if(m == "1") {
                        ken[str1] = str2;
                    }
                    if (m == "2") {
                        i--;
                    }
                }
            }

            while (true) {
                Console.WriteLine("**メニュー**");
                Console.WriteLine("1. 一覧表示");
                Console.WriteLine("2. 県庁所在地を検索");
                Console.WriteLine("3. 終了");

                var m = Console.ReadLine();

                if(m == "1") {
                    foreach (var kvp in ken) {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                }
                if (m == "2") {
                    Console.WriteLine("検索する都道府県を入力してください:");
                    string str1 = Console.ReadLine();
                    
                }
                if (m == "3") {
                    Console.WriteLine("終了します");
                    break;
                }

            }
        }
    }
}