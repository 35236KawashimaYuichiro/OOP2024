using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TextFileProcessor;

namespace LineCounter {
     class LineCounterProcessor :TextProcessor{

        private int _conut;
        string _text;
        protected override void Initialize(string fname) {
            _conut = 0;
        }

        protected override void Execute(string line) {
            //Console.WriteLine(line.ToUpper());
            _text = line;
            _conut++;
        }

        protected override void Terminate() {
            Console.WriteLine("{0} 行,", _conut);
            Console.WriteLine(_text);
        }
    }
}
