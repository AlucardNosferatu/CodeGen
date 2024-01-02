using System;
using System.Windows.Forms;

namespace ACG
{
    public partial class Form1 : Form
    {
        CodeGen cg;
        public Form1()
        {
            this.cg = new CodeGen();
            String po_string = this.cg.ProxyOut_write();
            String pi_string = this.cg.ProxyIn_write();
            String pi_url = this.cg.ProxyUrl_write();
            String rk_string = this.cg.RFKeyword_write();
            InitializeComponent();
        }
    }
}
