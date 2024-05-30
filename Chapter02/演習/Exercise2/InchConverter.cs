using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class InchConverter {

        //private const double ratio = 0.0254;  //定数
        public static readonly double ratio = 0.0254;
        public static readonly double ratio2 = 0.9144;//定数（外部にも公開する場合）

        //メートルからインチを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }
        //インチからメートルを求める
        public static double ToMeter(double inch) {
            return inch * ratio;
        }
 
        public static double FromYard(double meter) {
            return meter / ratio2;
        }
        public static double ToYard(double yard) {
            return yard * ratio2;
        }
    }
}