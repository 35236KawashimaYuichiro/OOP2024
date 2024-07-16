using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {

        private static Settings? instance; //自分自身のインスタンス

        public int MainFormColor { get; set; }

        private Settings() { }

        //自身のインスタンスを返却するメソッド
        public static Settings getInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
