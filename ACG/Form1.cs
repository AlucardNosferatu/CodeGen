using System;
using System.IO;
using System.Windows.Forms;

namespace ACG
{
    public partial class Form1 : Form
    {
        private CodeGen cg;
        public Form1()
        {
            string json_string = File.ReadAllText(path: "../../proxy_out.json");
            this.cg = new CodeGen(json_string: json_string);
            String po_string = this.cg.ProxyOut_write();
            String pi_string = this.cg.ProxyIn_write();
            String pi_url = this.cg.ProxyUrl_write();
            String rk_string = this.cg.RFKeyword_write();
            InitializeComponent();
        }
    }
}
