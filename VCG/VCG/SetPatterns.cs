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
    public partial class SetPatterns : Form
    {
        VT vt;
        public SetPatterns()
        {
            InitializeComponent();
        }
        public void loadVT(VT vt_in)
        {
            this.vt = vt_in;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SetPN_VT1_Click(object sender, EventArgs e)
        {
            String Temp = PatNum.Text;
            int TempInt;
            if (!int.TryParse(Temp,out TempInt))
            {
                PatNum.Text = "请输入数字！";
            }
            else
            {
                this.vt.PatNum_Site[SitesBox.SelectedIndex] = Convert.ToInt32(Temp);
                PatBox.Items.Clear();
                for (int i = 1; i <= this.vt.PatNum_Site[SitesBox.SelectedIndex]; i++)
                {
                    PatBox.Items.Add(i.ToString());
                }
            }
        }

        private void PatNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Temp = ShaderNo.Text;
            if (Temp.Length < 1)
            {
                ShaderNo.Text = "请输入编号！";
            }
            else
            {
                this.vt.PatOrd_Site[SitesBox.SelectedIndex, PatBox.SelectedIndex] = Convert.ToInt32(Temp);
            }
        }

        private void SetPatterns_Load(object sender, EventArgs e)
        {
            PatBox.Items.Clear();
            for (int i = 1; i <= this.vt.PatNum_Site[0]; i++)
            {
                PatBox.Items.Add(i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutputBox.Text = this.vt.PATTERN_write();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.vt.PatNum_Site = new int[] { 10, 11, 11, 7, 9 };
            this.vt.PatOrd_Site = new int[,] {
                { 0, 1, 3, 4, 5, 6, 7, 8, 9, 10, 10 },
                { 0, 1, 3, 4, 5, 6, 7, 8, 9, 3, 10 },
                { 0, 6, 2, 3, 1, 4, 5, 7, 8, 9, 10 },
                { 0, 1, 3, 4, 5, 7, 10, 10, 10, 10, 10 },
                { 0, 1, 3, 4, 5, 6, 7, 3, 10, 10, 10 }
            };
        }

        private void PatBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SitesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatBox.Items.Clear();
            for (int i = 1; i <= this.vt.PatNum_Site[SitesBox.SelectedIndex]; i++)
            {
                PatBox.Items.Add(i.ToString());
            }
        }
    }
}
