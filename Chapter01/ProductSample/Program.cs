using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123,"かりんとう",180);
            Product daihuku = new Product(235, "大福", 160);

            int price = karinto.Price;
            int taxIncluded = karinto.GetPriceIncludingTax();
            int price1 = daihuku.Price;
            int taxIncluded1 = daihuku.GetPriceIncludingTax();

            Console.WriteLine(karinto.Name + "の税込み価格：" + taxIncluded + "円【税抜き" + price + "円】");
            Console.WriteLine(daihuku.Name + "の税込み価格：" + taxIncluded1 + "円【税抜き" + price1 + "円】");

        }
    }
}
