using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class MetricWeightUnit : WeightUnit {
        private static readonly List<MetricWeightUnit> units = new List<MetricWeightUnit> {
            new MetricWeightUnit { Name = "µg", Coefficient = 0.000001 }, // マイクログラム
            new MetricWeightUnit { Name = "mg", Coefficient = 0.001 },    // ミリグラム
            new MetricWeightUnit { Name = "g", Coefficient = 1 },         // グラム
            new MetricWeightUnit { Name = "kg", Coefficient = 1000 },     // キログラム
            new MetricWeightUnit { Name = "ct", Coefficient = 0.2 },      // カラット 
            new MetricWeightUnit { Name = "t", Coefficient = 1000000 }    // トン 
        };

        public static ICollection<MetricWeightUnit> Units { get { return units; } }

        public double FromImperialUnit(ImperialWeightUnit unit, double value) {
            return (value * unit.Coefficient) * 28.3495 / this.Coefficient; 
        }
    }
}