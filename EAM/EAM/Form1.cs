using System.Windows.Forms;

namespace EAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Monster M = new Monster();
            M.namespace_as = "BarneyCustom";
            M.ally = true;
            M.mdl_path = "models/monsters/motherfucker.mdl";
            M.sound_paths.Add("sounds/fucking.wav");
            M.sound_paths.Add("sounds/sucking.wav");
            M.sound_paths.Add("sounds/cumming.wav");
            string PrecStr = StrConverter.GetPrecacheMethodStr(M);
            InitializeComponent();
        }
    }
}
