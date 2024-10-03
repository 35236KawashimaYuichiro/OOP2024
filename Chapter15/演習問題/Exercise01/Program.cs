using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();

        }

        private static void Exercise1_2() {
            var book = Library.Books.OrderByDescending(b => b.Price).First();
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var books = Library.Books.GroupBy(b => b.PublishedYear).Select(g => new {
                PublishedYear = g.Key,
                Count = g.Count()
            })
                .OrderBy(y => y.PublishedYear);
            foreach (var yearGroup in books) {
                Console.WriteLine($"発行年: {yearGroup.PublishedYear}, 書籍数: {yearGroup.Count}");
            }
        }

        private static void Exercise1_4() {
            var sortedBooks = Library.Books
        .Join(Library.Categories,
            b => b.CategoryId,
            category => category.Id,
            (book, category) => new {
                book.PublishedYear,
                book.Price,
                book.Title,
                CategoryName = category.Name
            })
        .OrderByDescending(b => b.PublishedYear)
        .ThenByDescending(b => b.Price);

            foreach (var book in sortedBooks) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}（{book.CategoryName}）");
            }
        }

        private static void Exercise1_5() {
            var categoryIds = Library.Books
                            .Where(b => b.PublishedYear == 2016)
                            .Select(b => b.CategoryId)
                            .Distinct();

            var categories = Library.Categories
                            .Where(c => categoryIds.Contains(c.Id))
                            .Select(c => c.Name);

            Console.WriteLine("2016年発行書籍カテゴリー");
            foreach (var category in categories) {
                Console.WriteLine($"　{category}");
            }
        }

        private static void Exercise1_6() {
            var books = Library.Books
                .GroupBy(b => b.CategoryId)
                .OrderBy(g => Library.Categories.First(c => c.Id == g.Key).Name);

            foreach (var group in books) {
                var categoryName = Library.Categories.First(c => c.Id == group.Key).Name;
                Console.WriteLine($"#{categoryName}");

                foreach (var book in group) {
                    Console.WriteLine(book.Title);
                }
            }
        }

        private static void Exercise1_7() {
            var categoriesId = Library.Categories.Single(c => c.Name == "Development").Id;
            var query = Library.Books.Where(b => b.CategoryId == categoriesId)
                                        .GroupBy(b => b.PublishedYear)
                                        .OrderBy(b => b.Key);
            foreach (var group in query) {
                Console.WriteLine("#{0}年", group.Key);
                foreach (var item in group) {
                    Console.WriteLine("  {0}", item.Title);
                }
            }
        }


        private static void Exercise1_8() {
            var categoriBooks = Library.Categories
            .GroupJoin(
                Library.Books,
                category => category.Id,
                book => book.CategoryId,
                (category, books) => new {
                    CategoryName = category.Name,
                    BookCount = books.Count()
                })
                .Where(category => category.BookCount >= 4);

            Console.WriteLine("4冊以上発行されているカテゴリ:");
            foreach (var category in categoriBooks) {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}
