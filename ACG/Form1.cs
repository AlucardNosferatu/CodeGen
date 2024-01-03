using System.Windows.Forms;

namespace ACG
{
    public partial class Form1 : Form
    {
        CodeGen cg;
        JsonWriter jw;
        public Form1()
        {
            string[] tt_names = { "timetable", "enable_days", "start", "end" };
            this.jw = new JsonWriter(p_dict_name: "cmd_dict", tt_names: tt_names, ts_name: "timestamp");
            //this.cg = new CodeGen();
            //String po_string = this.cg.ProxyOut_write();
            //String pi_string = this.cg.ProxyIn_write();
            //String pi_url = this.cg.ProxyUrl_write();
            //String rk_string = this.cg.RFKeyword_write();
            InitializeComponent();
        }
    }
}
