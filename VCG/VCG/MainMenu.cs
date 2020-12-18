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
    public partial class MainMenu : Form
    {
        VT vt;
        public MainMenu()
        {
            InitializeComponent();
            this.vt = new VT();
        }

        private void SetPins_Click(object sender, EventArgs e)
        {
            SetPins SP = new SetPins();
            SP.loadVT(vt);
            SP.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetSites SS = new SetSites();
            SS.loadVT(vt);
            SS.ShowDialog();
        }

        private void SetPatterns_Click(object sender, EventArgs e)
        {
            SetPatterns SPA = new SetPatterns();
            SPA.loadVT(vt);
            SPA.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetColor SC = new SetColor();
            SC.loadVT(vt);
            SC.ShowDialog();
        }
    }
}
