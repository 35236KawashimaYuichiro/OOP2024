using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

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

            var newfile = "kanzi.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var teams = xdoc.Root.Elements()
                                .Select(x => new {
                                    Name = (string)x.Element("name"),
                                    Member = (int)x.Element("teammembers")
                                });

            foreach (var team in teams) {
                Console.WriteLine($"{team.Name},{team.Member}人");
            }

        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var kanzi = xdoc.Root.Elements("ballsport")
                                 .Select(x => new {
                                     NameKanji = (string)x.Element("name").Attribute("kanji"),
                                     FirstPlayed = (int)x.Element("firstplayed")
                                 })
                                 .OrderBy(x => x.FirstPlayed);

            foreach (var bs in kanzi) {
                Console.WriteLine($"{bs.NameKanji}:{bs.FirstPlayed}年");
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var member = xdoc.Root.Elements("ballsport")
                                 .Select(x => new {
                                     Name = (string)x.Element("name"),
                                     TeamMembers = (int)x.Element("teammembers")
                                 })
                                 .OrderByDescending(x => x.TeamMembers)
                                 .First();
            Console.WriteLine($"{member.Name}");

        }

        private static void Exercise1_4(string file, string newfile) {
            var xdoc = XDocument.Load(file);

            var soccerData = new XElement("ballsport",
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", 11),
                new XElement("firstplayed", 1863)
            );

            xdoc.Root.Add(soccerData);
            xdoc.Save(newfile);

            Console.WriteLine($"サッカーの情報を追加しました。");
            Exercise1_1(newfile);



            Console.Write("スポーツ名: ");
            string sportName = Console.ReadLine();

            Console.Write("漢字表記: ");
            string kanji = Console.ReadLine();

            Console.Write("チームメンバー数: ");
            int teamMembers = int.Parse(Console.ReadLine());

            Console.Write("最初にプレイされた年: ");
            int firstPlayed = int.Parse(Console.ReadLine());

            var element = new XElement("ballsport",
                new XElement("name", sportName, new XAttribute("kanji", kanji)),
                new XElement("teammembers", teamMembers),
                new XElement("firstplayed", firstPlayed));

            xdoc.Root.Add(element);
            xdoc.Save(newfile);

            Exercise1_1(newfile);
        }

    }
}