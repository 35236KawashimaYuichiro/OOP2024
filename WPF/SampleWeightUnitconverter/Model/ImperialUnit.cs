using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class ImperialWeightUnit : WeightUnit {
        private static List<ImperialWeightUnit> units = new List<ImperialWeightUnit> {
            new ImperialWeightUnit { Name = "oz", Coefficient = 1 },       // オンス
            new ImperialWeightUnit { Name = "lb", Coefficient = 16 }       // ポンド (1ポンド = 16オンス)
        };
        public static ICollection<ImperialWeightUnit> Units { get { return units; } }

        public double FromMetricUnit(MetricWeightUnit unit, double value) {
            return (value * unit.Coefficient) / 28.3495 / this.Coefficient; // グラムから変換
        }
    }
}