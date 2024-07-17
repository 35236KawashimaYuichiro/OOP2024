using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            XDocument xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements("ballsport");

            foreach (var sport in sports) {
                var name = sport.Element("name").Value;
                var teamMembers = sport.Element("teammembers").Value;
                Console.WriteLine($"{name}: {teamMembers}人");
            }
        }

        private static void Exercise1_2(string file) {
            XDocument xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements("ballsport").OrderBy(sport => (sport.Element("firstplayed").Value));

            foreach (var sport in sports) {
                string kanjiName = sport.Element("name").Attribute("kanji").Value;
                Console.WriteLine(kanjiName);
            }

        }

        private static void Exercise1_3(string file) {
            XDocument xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements("ballsport")
                                 .OrderByDescending(sport => (sport.Element("teammembers").Value))
                                 .First();
            string name = sports.Element("name").Value;

            Console.WriteLine(name);
        }

        private static void Exercise1_4(string file, string newfile) {
        }
    }
}
