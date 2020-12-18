using System.Collections;

namespace EAM
{
    class Monster
    {
        public string namespace_as;
        public string class_name;
        public bool ally;
        public string mdl_path;
        public ArrayList sound_paths;
        public ArrayList pain_sounds;
        public ArrayList death_sounds;
        public ArrayList alert_sounds;

        public Monster()
        {
            this.sound_paths = new ArrayList();
        }

    }

    class StrConverter
    {

        public static string GetPrecacheMethodStr(Monster M)
        {
            string temp_str = "";
            temp_str += "void Precache()\n";
            temp_str += "{\n";
            temp_str += "g_Game.PrecacheModel(\"" + M.mdl_path + "\");\n";
            foreach (string sound_path in M.sound_paths)
            {
                temp_str += ("g_SoundSystem.PrecacheSound(\"" + sound_path + "\");\n");
            }
            temp_str += "}\n";

            return temp_str;
        }
    }
}
