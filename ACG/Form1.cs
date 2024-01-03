using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ACG
{
    public partial class MainForm : Form
    {
        private CodeGen cg;
        private bool ok;
        public MainForm()
        {
            this.ok = false;
            InitializeComponent();
        }
        private void parseJson_Click(object sender, System.EventArgs e)
        {
            String json_string = jsonInputBox.Text;
            Dictionary<String, String> string_dict = new Dictionary<String, String>();
            Dictionary<String, bool> bool_dict = new Dictionary<String, bool>();
            //this.proxy_out_api_url = string_dict[key: "proxy_out_api_url"];
            //this.proxy_out_func_path = string_dict[key: "proxy_out_func_path"];
            //this.proxy_in_func_file = string_dict[key: "proxy_in_func_file"];
            //this.proxy_url_prefix = string_dict[key: "proxy_url_prefix"];
            //this.specified_action_name = string_dict[key: "specified_action_name"];
            //this.cmd_string = string_dict[key: "cmd_string"];
            //this.has_end_morning = bool_dict[key: "has_end_morning"];
            //this.is_cmd = bool_dict[key: "is_cmd"];
            //this.get_cmd_result = bool_dict[key: "get_cmd_result"];
            string_dict[key: "proxy_out_api_url"] = pout_url_tbox.Text;
            string_dict[key: "proxy_out_func_path"] = pout_path_tbox.Text;
            string_dict[key: "proxy_in_func_file"] = pin_file_tbox.Text;
            string_dict[key: "proxy_url_prefix"] = pin_url_tbox.Text;
            string_dict[key: "specified_action_name"] = sp_an_tbox.Text;
            string_dict[key: "cmd_string"] = cmd_str_label.Text;
            bool_dict[key: "has_end_morning"] = has_em_cbox.Checked;
            bool_dict[key: "is_cmd"] = is_cmd_cbox.Checked;
            bool_dict[key: "get_cmd_result"] = get_result_cbox.Checked;
            this.cg = new CodeGen(json_string: json_string, string_dict: string_dict, bool_dict: bool_dict);
            this.ok = true;
        }

        private void genProxyOut_Click(object sender, EventArgs e)
        {
            if (this.ok)
            {
                String po_string = this.cg.ProxyOut_write();
                outputBox.Text = po_string;
            }
            else
            {
                outputBox.Text = "还没解析Json";
            }
        }

        private void genProxyIn_Click(object sender, EventArgs e)
        {
            if (this.ok)
            {
                String pi_string = this.cg.ProxyIn_write();
                outputBox.Text = pi_string;
            }
            else
            {
                outputBox.Text = "还没解析Json";
            }
        }

        private void genProxyURL_Click(object sender, EventArgs e)
        {
            if (this.ok)
            {
                String pi_url = this.cg.ProxyUrl_write();
                outputBox.Text = pi_url;
            }
            else
            {
                outputBox.Text = "还没解析Json";
            }
        }

        private void genRFKeyword_Click(object sender, EventArgs e)
        {
            if (this.ok)
            {
                String rk_string = this.cg.RFKeyword_write();
                outputBox.Text = rk_string;
            }
            else
            {
                outputBox.Text = "还没解析Json";
            }
        }
    }
}
