using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void btVersionOK_Click(object sender, EventArgs e) {
            Close();
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;
            label2.Text = $"Version: {version}";

            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var cn = fileVersionInfo.CompanyName;
            label3.Text = cn;
        }
    }
}
