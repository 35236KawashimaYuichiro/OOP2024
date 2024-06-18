﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    class Program {
        static void Main(string[] args) {
            var score = new ScoreCounter("StudentScore.csv");
            IDictionary<string, int> TotalBySubject = score.GetPerStudentScore();
            foreach (KeyValuePair<string, int> obj in TotalBySubject) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }
        }
    }
}
