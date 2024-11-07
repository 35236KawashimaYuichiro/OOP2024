﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class GramUnit : WeightUnit {
        private static readonly List<GramUnit> units = new List<GramUnit> {
            new GramUnit { Name = "µg", Coefficient = 0.000001 }, // マイクログラム
            new GramUnit { Name = "mg", Coefficient = 0.001 },    // ミリグラム
            new GramUnit { Name = "g", Coefficient = 1 },         // グラム
            new GramUnit { Name = "kg", Coefficient = 1000 },     // キログラム
            new GramUnit { Name = "ct", Coefficient = 0.2 },      // カラット 
            new GramUnit { Name = "t", Coefficient = 1000000 }    // トン 
        };

        public static ICollection<GramUnit> Units { get { return units; } }

        public double FromImperialUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 28.3495 / this.Coefficient; 
        }
    }
}