﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks().OrderByDescending(b=>b.Price).ToList();
            books.ForEach(b =>Console.WriteLine(b.Title + ":" + b.Price));
           
        }
    }
}
