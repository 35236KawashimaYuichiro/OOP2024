using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TextFileProcessor;

namespace TextNumberSizeChange {
     class ToHankakuProcessor :TextProcessor{

        private int _count;
        private StringBuilder _textBuilder;

        protected override void Initialize(string fname) {
            _count = 0;
            _textBuilder = new StringBuilder();
        }

        protected override void Execute(string line) {
            string convertedLine = ConvertToHankaku(line);
            _textBuilder.AppendLine(convertedLine);
            _count++;
        }

        protected override void Terminate() {
            Console.WriteLine("{0} 行処理されました。", _count);
            Console.WriteLine(_textBuilder.ToString());
        }

        private string ConvertToHankaku(string input) {
            var sb = new StringBuilder(input.Length);
            foreach (char c in input) {
                switch (c) {
                    case '０': sb.Append('0'); break;
                    case '１': sb.Append('1'); break;
                    case '２': sb.Append('2'); break;
                    case '３': sb.Append('3'); break;
                    case '４': sb.Append('4'); break;
                    case '５': sb.Append('5'); break;
                    case '６': sb.Append('6'); break;
                    case '７': sb.Append('7'); break;
                    case '８': sb.Append('8'); break;
                    case '９': sb.Append('9'); break;
                    default: sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
    }
}

