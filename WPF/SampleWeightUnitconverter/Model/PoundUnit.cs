using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class ImperialWeightUnit : WeightUnit {
        private static readonly List<ImperialWeightUnit> units = new List<ImperialWeightUnit> {
            //new ImperialWeightUnit { Name = "gr", Coefficient = 1.0 / 7000 }, // グレーン 
            //new ImperialWeightUnit { Name = "dr", Coefficient = 1.0 / 256 },  // ドラム 
            new ImperialWeightUnit { Name = "oz", Coefficient = 1 },          // オンス
            new ImperialWeightUnit { Name = "lb", Coefficient = 16 },        // ポンド 
            new ImperialWeightUnit { Name = "st", Coefficient = 224 },       // ストーン 
            new ImperialWeightUnit { Name = "long ton", Coefficient = 35840 }, // トン (ロングトン)
            new ImperialWeightUnit { Name = "short ton", Coefficient = 32000 }, // トン (ショートトン)
            new ImperialWeightUnit { Name = "cwt (long)", Coefficient = 1792 },  // ハンドレッドウェイト (ロング)
            new ImperialWeightUnit { Name = "cwt (short)", Coefficient = 1600 }  // ハンドレッドウェイト (ショート)
        };

        public static ICollection<ImperialWeightUnit> Units { get { return units; } }

        public double FromMetricUnit(MetricWeightUnit unit, double value) {
            return (value * unit.Coefficient) / 28.3495 / this.Coefficient; 
        }
    }
}