using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCG
{
    public partial class SetSites : Form
    {
        VT vt;
        public SetSites()
        {
            InitializeComponent();
        }
        public void loadVT(VT vt_in)
        {
            this.vt = vt_in;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectSite_Click(object sender, EventArgs e)
        {
            String site_str;
            int site_num = SitesBox.SelectedIndex;
            switch (site_num) {
                case 0:
                    site_str = "VT1";
                    break;
                case 1:
                    site_str = "VT2";
                    break;
                case 2:
                    site_str = "Laser";
                    break;
                case 3:
                    site_str = "AOI";
                    break;
                case 4:
                    site_str = "VT2_jingjian";
                    break;
                default:
                    site_str = "VT1";
                    break;
            }
            OutputBox.Text = this.vt.SITE_write(site_str);
        }
    }
}
