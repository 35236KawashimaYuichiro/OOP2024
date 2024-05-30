using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);


            // 4.2.4
            Console.WriteLine("\n- 4.2.4 ---");
            Exercise2_4(ymCollection);

            // 4.2.5
            Console.WriteLine("\n- 4.2.5 ---");
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }
        private static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                if (ym.Is21Century) {
                    return ym;
                }
            }
            return null;
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            YearMonth fym = FindFirst21C(ymCollection);
            if (fym != null) {
                Console.WriteLine("最初に見つかった21世紀のデータの年:" + fym.Year);
            } else {
                Console.WriteLine("21世紀のデータはありません");
            }
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var nextMonth = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in nextMonth) {
                Console.WriteLine(ym);
            }
        }
    }
}
