﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1_1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise1_2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise1_3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise1_4(numbers);
        }

        private static void Exercise1_1(List<int> numbers) {

            var e = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);
            Console.WriteLine(e);
            //IEnumerable<int> query = numbers.Where(s => s % 8 == 0 || s % 9 == 0);
            //foreach (int s in query) {
            //    Console.WriteLine(s);
            //}
        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(s => Console.WriteLine(s / 2.0));
        }

        private static void Exercise1_3(List<int> numbers) {
            //IEnumerable<int> query = numbers.Where(s => s >= 50);
            //Console.WriteLine(query.Count());
            numbers.Where(n => 50 <= n).ToList().ForEach(n => Console.WriteLine(n));
        }

        private static void Exercise1_4(List<int> numbers) {
            //IEnumerable<int> query = numbers.Select(s => s * 2);
            //foreach (int s in query) {
            //    Console.WriteLine(s);
            //}
            numbers.Select(n => n * 2).ToList().ForEach(n => Console.WriteLine(n));
        }
    }
}
