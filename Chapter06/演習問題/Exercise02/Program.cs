using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }

    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);
        }

        private static void Exercise2_1(List<Book> books) {
            var wb = books.FirstOrDefault(book => book.Title == "ワンダフル・C#ライフ");
            Console.WriteLine($" 価格: {wb.Price}, ページ数: {wb.Pages}");
        }

        private static void Exercise2_2(List<Book> books) {
            var cb = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(cb);
        }

        private static void Exercise2_3(List<Book> books) {
            var ab = books.Where(b => b.Title.Contains("C#")).Average(book => book.Pages);
            Console.WriteLine(ab);
        }

        private static void Exercise2_4(List<Book> books) {
            var bb = books.FirstOrDefault(b => b.Price >= 4000);
            Console.WriteLine(bb.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var bb = books.Where(b => b.Price < 4000).Max(book => book.Pages);
            Console.WriteLine(bb);
        }

        private static void Exercise2_6(List<Book> books) {
            var sb = books.Where(b => b.Pages >= 400)
                                    .OrderByDescending(book => book.Price);
            foreach (var book in sb) {
                Console.WriteLine($"タイトル: {book.Title}, 価格: {book.Price}");
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var pb = books.Where(book => book.Title.Contains("C#") && book.Pages <= 500);
            foreach (var b in pb) {
                Console.WriteLine($"タイトル: {b.Title}");
            }
        }
    }
}
