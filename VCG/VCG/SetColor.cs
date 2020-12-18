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
    public partial class SetColor : Form
    {
        VT vt;

        public SetColor()
        {
            InitializeComponent();
        }

        public void loadVT(VT vt_in)
        {
            this.vt = vt_in;
        }

        private void SetColor_Load(object sender, EventArgs e)
        {
            NormalMode.Checked = true;
            Custom.Checked = true;
            PatBox.Items.Clear();
            for (int i = 1; i <= this.vt.pattern_count; i++)
            {
                PatBox.Items.Add(i.ToString());
            }
            PatBox.SelectedIndex = 0;

        }

        private void SetPN_Click(object sender, EventArgs e)
        {
            String Temp = PatNum.Text;
            int TempInt;
            if (!int.TryParse(Temp, out TempInt))
            {
                PatNum.Text = "输入非零数字！";
            }
            else
            {
                int Temp_num = Convert.ToInt32(Temp);
                if (Temp_num == 0)
                {
                    PatNum.Text = "输入非零数字！";
                }
                else
                {
                    this.vt.pattern_count = Temp_num;
                    PatBox.Items.Clear();
                    for (int i = 1; i <= this.vt.pattern_count; i++)
                    {
                        PatBox.Items.Add(i.ToString());
                    }
                }
            }
            PatBox.SelectedIndex = 0;
        }

        private void SetPC_Click(object sender, EventArgs e)
        {
            int mode;
            if (NormalMode.Checked)
            {
                mode = 0;
            }
            else if (UBDW.Checked)
            {
                mode = 1;
            }
            else if (UWDB.Checked)
            {
                mode = 2;
            }
            else
            {
                mode = 0;
            }
            switch (mode)
            {
                case 0:
                    this.vt.shader_data[PatBox.SelectedIndex, 0] = RBox.Text;
                    this.vt.shader_data[PatBox.SelectedIndex, 1] = GBox.Text;
                    this.vt.shader_data[PatBox.SelectedIndex, 2] = BBox.Text;
                    break;
                case 1:
                    this.vt.shader_data[PatBox.SelectedIndex, 0] = "pat_blc_wht_h[23:16]";
                    this.vt.shader_data[PatBox.SelectedIndex, 1] = "pat_blc_wht_h[15:8]";
                    this.vt.shader_data[PatBox.SelectedIndex, 2] = "pat_blc_wht_h[7:0]";
                    break;
                case 2:
                    this.vt.shader_data[PatBox.SelectedIndex, 0] = "pat_wht_blc_h[23:16]";
                    this.vt.shader_data[PatBox.SelectedIndex, 1] = "pat_wht_blc_h[15:8]";
                    this.vt.shader_data[PatBox.SelectedIndex, 2] = "pat_wht_blc_h[7:0]";
                    break;
                default:
                    this.vt.shader_data[PatBox.SelectedIndex, 0] = RBox.Text;
                    this.vt.shader_data[PatBox.SelectedIndex, 1] = GBox.Text;
                    this.vt.shader_data[PatBox.SelectedIndex, 2] = BBox.Text;
                    break;
            }
            if (Custom.Checked && NormalMode.Checked)
            {
                int R = 0, G = 0, B = 0;
                String TempR;
                String TempG;
                String TempB;
                if (RBox.Text.Contains("8'd")&& GBox.Text.Contains("8'd")&& BBox.Text.Contains("8'd"))
                {
                    TempR = RBox.Text.Remove(0, 3);
                    TempG = GBox.Text.Remove(0, 3);
                    TempB = BBox.Text.Remove(0, 3);
                    if (!int.TryParse(TempR, out R)|| !int.TryParse(TempG, out G)|| !int.TryParse(TempB, out B))
                    {
                        OutputBox.Text = "自定颜色参数格式：\r\n8'd+灰度数值\r\n取值范围：127~255（127阶对应实际显示255阶）";
                    }
                    else
                    {
                        R = (R-127)*2;
                        G = (G-127)*2;
                        B = (B-127)*2;
                        if (R > 255)
                        {
                            R = 255;
                        }
                        if (G > 255)
                        {
                            G = 255;
                        }
                        if (B > 255)
                        {
                            B = 255;
                        }
                        if (R < 0)
                        {
                            R = 0;
                        }
                        if (G < 0)
                        {
                            G = 0;
                        }
                        if (B < 0)
                        {
                            B = 0;
                        }
                        PatUp.BackColor = Color.FromArgb(R, G, B);
                        PatDown.BackColor = Color.FromArgb(R, G, B);
                    }

                }

            }
        }

        private void NormalMode_CheckedChanged(object sender, EventArgs e)
        {
            if (NormalMode.Checked)
            {
                UWDB.Checked = false;
                UBDW.Checked = false;
                Custom.Checked = true;
                White.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "8'd";
                GBox.Text = "8'd";
                BBox.Text = "8'd";
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
                PatUp.BackColor = Color.White;
                PatDown.BackColor = Color.White;
            }
        }

        private void UBDW_CheckedChanged(object sender, EventArgs e)
        {
            if (UBDW.Checked)
            {
                UWDB.Checked = false;
                NormalMode.Checked = false;
                Custom.Checked = false;
                White.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "";
                GBox.Text = "";
                BBox.Text = "";
                RBox.ReadOnly = true;
                GBox.ReadOnly = true;
                BBox.ReadOnly = true;
                PatUp.BackColor = Color.Black;
                PatDown.BackColor = Color.White;
            }
        }

        private void UWDB_CheckedChanged(object sender, EventArgs e)
        {
            if (UWDB.Checked)
            {
                UBDW.Checked = false;
                NormalMode.Checked = false;
                Custom.Checked = false;
                White.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "";
                GBox.Text = "";
                BBox.Text = "";
                RBox.ReadOnly = true;
                GBox.ReadOnly = true;
                BBox.ReadOnly = true;
                PatUp.BackColor = Color.White;
                PatDown.BackColor = Color.Black;
            }
        }

        private void ShowCode_Click(object sender, EventArgs e)
        {
            OutputBox.Text = vt.COLOR_write();
        }

        private void White_CheckedChanged(object sender, EventArgs e)
        {
            if (White.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                Custom.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "DCODE_WHITE";
                GBox.Text = "DCODE_WHITE";
                BBox.Text = "DCODE_WHITE";
                PatUp.BackColor = Color.White;
                PatDown.BackColor = Color.White;
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void Custom_CheckedChanged(object sender, EventArgs e)
        {
            if (Custom.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "8'd";
                GBox.Text = "8'd";
                BBox.Text = "8'd";
                PatUp.BackColor = Color.White;
                PatDown.BackColor = Color.White;
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void Black_CheckedChanged(object sender, EventArgs e)
        {
            if (Black.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Custom.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "DCODE_BLACK";
                GBox.Text = "DCODE_BLACK";
                BBox.Text = "DCODE_BLACK";
                PatUp.BackColor = Color.Black;
                PatDown.BackColor = Color.Black;
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void Red_CheckedChanged(object sender, EventArgs e)
        {
            if (Red.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Custom.Checked = false;
                Black.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "DCODE_WHITE";
                GBox.Text = "DCODE_BLACK";
                BBox.Text = "DCODE_BLACK";
                PatUp.BackColor = Color.Red;
                PatDown.BackColor = Color.Red;
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void Green_CheckedChanged(object sender, EventArgs e)
        {
            if (Green.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Custom.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "DCODE_BLACK";
                GBox.Text = "DCODE_WHITE";
                BBox.Text = "DCODE_BLACK";
                PatUp.BackColor = Color.Green;
                PatDown.BackColor = Color.Green;
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void Blue_CheckedChanged(object sender, EventArgs e)
        {
            if (Blue.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Custom.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                G128.Checked = false;
                G64.Checked = false;

                RBox.Text = "DCODE_BLACK";
                GBox.Text = "DCODE_BLACK";
                BBox.Text = "DCODE_WHITE";
                PatUp.BackColor = Color.Blue;
                PatDown.BackColor = Color.Blue;
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void G128_CheckedChanged(object sender, EventArgs e)
        {
            if (G128.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Custom.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G64.Checked = false;

                RBox.Text = "DCODE_GRAY128";
                GBox.Text = "DCODE_GRAY128";
                BBox.Text = "DCODE_GRAY128";
                PatUp.BackColor = Color.FromArgb(128, 128, 128);
                PatDown.BackColor = Color.FromArgb(128, 128, 128);
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }
        }

        private void G64_CheckedChanged(object sender, EventArgs e)
        {
            if (G64.Checked)
            {
                NormalMode.Checked = true;
                UWDB.Checked = false;
                UBDW.Checked = false;

                White.Checked = false;
                Custom.Checked = false;
                Black.Checked = false;
                Red.Checked = false;
                Green.Checked = false;
                Blue.Checked = false;
                G128.Checked = false;

                RBox.Text = "DCODE_GRAY64";
                GBox.Text = "DCODE_GRAY64";
                BBox.Text = "DCODE_GRAY64";
                PatUp.BackColor = Color.FromArgb(64, 64, 64);
                PatDown.BackColor = Color.FromArgb(64, 64, 64);
                RBox.ReadOnly = false;
                GBox.ReadOnly = false;
                BBox.ReadOnly = false;
            }

        }
    }
}
