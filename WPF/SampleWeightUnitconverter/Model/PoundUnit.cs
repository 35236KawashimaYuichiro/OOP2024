using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class PoundUnit : WeightUnit {
        private static readonly List<PoundUnit> units = new List<PoundUnit> {
            //new PoundUnit { Name = "gr", Coefficient = 1.0 / 7000 }, // グレーン 
            //new PoundUnit { Name = "dr", Coefficient = 1.0 / 256 },  // ドラム 
            new PoundUnit { Name = "oz", Coefficient = 1 },          // オンス
            new PoundUnit { Name = "lb", Coefficient = 16 },        // ポンド 
            new PoundUnit { Name = "st", Coefficient = 224 },       // ストーン 
            new PoundUnit { Name = "long ton", Coefficient = 35840 }, // トン (ロングトン)
            new PoundUnit { Name = "short ton", Coefficient = 32000 }, // トン (ショートトン)
            new PoundUnit { Name = "cwt (long)", Coefficient = 1792 },  // ハンドレッドウェイト (ロング)
            new PoundUnit { Name = "cwt (short)", Coefficient = 1600 }  // ハンドレッドウェイト (ショート)
        };

        public static ICollection<PoundUnit> Units { get { return units; } }

        public double FromMetricUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.3495 / this.Coefficient; 
        }
    }
}