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
    public partial class SetPins : Form
    {
        VT vt;
        public SetPins()
        {
            InitializeComponent();
        }
        public void loadVT(VT vt_in)
        {
            this.vt = vt_in;
        }
        private void MainPanel_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Generate
        {
            if (stv_num_box.Text.Length < 1 || ckv_num_box.Text.Length < 1 || ckh_num_box.Text.Length < 1 || vtcomsw_num_box.Text.Length < 1)
            {
                OutputBox.Text = "四个主要逻辑信号个数为必填项";
            }
            else
            {
                int stv_num = Convert.ToInt32(stv_num_box.Text);
                int ckv_num = Convert.ToInt32(ckv_num_box.Text);
                int ckh_num = Convert.ToInt32(ckh_num_box.Text);
                int vtcomsw_num = Convert.ToInt32(vtcomsw_num_box.Text);
                int[] signal_num = { stv_num, ckv_num, ckh_num, vtcomsw_num };
                String[,] signals = new String[14, 2];
                signals[0, 0] = mux1_a_box.Text;
                signals[0, 1] = mux1_b_box.Text;
                signals[1, 0] = mux2_a_box.Text;
                signals[1, 1] = mux2_b_box.Text;
                signals[2, 0] = mux3_a_box.Text;
                signals[2, 1] = mux3_b_box.Text;
                signals[3, 0] = mux4_a_box.Text;
                signals[3, 1] = mux4_b_box.Text;
                signals[4, 0] = mux5_a_box.Text;
                signals[4, 1] = mux5_b_box.Text;
                signals[5, 0] = mux6_a_box.Text;
                signals[5, 1] = mux6_b_box.Text;
                signals[6, 0] = mux7_a_box.Text;
                signals[6, 1] = mux7_b_box.Text;
                signals[7, 0] = mux8_a_box.Text;
                signals[7, 1] = mux8_b_box.Text;
                signals[8, 0] = mux9_a_box.Text;
                signals[8, 1] = mux9_b_box.Text;
                signals[9, 0] = mux10_a_box.Text;
                signals[9, 1] = mux10_b_box.Text;
                signals[10, 0] = mux11_a_box.Text;
                signals[10, 1] = mux11_b_box.Text;
                signals[11, 0] = mux12_a_box.Text;
                signals[11, 1] = mux12_b_box.Text;
                signals[12, 0] = mux13_a_box.Text;
                signals[12, 1] = mux13_b_box.Text;
                signals[13, 0] = mux14_a_box.Text;
                signals[13, 1] = mux14_b_box.Text;
                this.vt.SignalNum = signal_num;
                this.vt.Signals = signals;
                OutputBox.Text = this.vt.PIN_write();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
