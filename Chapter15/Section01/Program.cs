using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Library.Books
                        .GroupBy(x => x.PublishedYear)
                        .OrderBy(x => x.Key);


            foreach (var b in books) {
                Console.WriteLine($"{b.Key}年");
                foreach (var a in b) {
                    Console.WriteLine($"{b}");
                }
            }
        }
    }
}
