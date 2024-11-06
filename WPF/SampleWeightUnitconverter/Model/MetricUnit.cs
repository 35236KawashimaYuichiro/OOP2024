using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class MetricWeightUnit : WeightUnit {
        private static List<MetricWeightUnit> units = new List<MetricWeightUnit> {
            new MetricWeightUnit { Name = "g", Coefficient = 1 },          // グラム
            new MetricWeightUnit { Name = "kg", Coefficient = 1000 }       // キログラム
        };
        public static ICollection<MetricWeightUnit> Units { get { return units; } }

        public double FromImperialUnit(ImperialWeightUnit unit, double value) {
            return (value * unit.Coefficient) * 28.3495 / this.Coefficient; // オンスからグラムに変換
        }
    }
}