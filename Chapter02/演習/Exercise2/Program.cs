using DistanceConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    internal class Program {
        static void Main(string[] args) {

            if (args.Length >= 1 && args[0] == "-tom") {
                //インチからメートルへの対応表を出力
                PrintInchToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            } else {
                //メートルからインチへの対応表を出力
                PrintMeterToInchList(int.Parse(args[1]), int.Parse(args[2]));
            }

            if (args.Length >= 1 && args[0] == "-tom") {
                //インチからメートルへの対応表を出力
                PrintYardToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            } else {
                //メートルからインチへの対応表を出力
                PrintMeterToYardList(int.Parse(args[1]), int.Parse(args[2]));
            }


        }
        private static void PrintInchToMeterList(int start, int stop) {
            for (double inch = start; inch <= stop; inch++) {
                double meter = InchConverter.FromMeter(inch);
                Console.WriteLine("{0} ic = {1:0.0000} m", inch, meter);
            }
        }
        private static void PrintMeterToInchList(int start, int stop) {
            for (double meter = start; meter <= stop; meter++) {
                double inch = InchConverter.ToMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, inch);
            }
        }

        private static void PrintYardToMeterList(int start, int stop) {
            for (double yard = start; yard <= stop; yard++) {
                double meter = InchConverter.FromYard(yard);
                Console.WriteLine("{0} yd = {1:0.0000} m", yard, meter);
            }
        }
        private static void PrintMeterToYardList(int start, int stop) {
            for (double meter = start; meter <= stop; meter++) {
                double yard = InchConverter.ToYard(meter);
                Console.WriteLine("{0} m = {1:0.0000} yd", meter, yard);
            }
        }
    }
}
