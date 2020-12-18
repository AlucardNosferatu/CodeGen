using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VCG
{
    public class VT
    {
        public int DCODE_WHITE;
        public int DCODE_BLACK;
        public int DCODE_GRAY128;
        public int DCODE_GRAY64;

        public int pattern_count;
        public String[,] shader_data;

        public int[] SignalNum;
        public String[,] Signals;
        String[] Contents;
        public int[] PatNum_Site;
        public int[,] PatOrd_Site;
        static void Main(string[] args){
            //VT vt = new VT();
            //vt.Signals = new string[14,3];
            //vt.Contents=new String[200];
            //Console.WriteLine("Input file path");
            //String filepath=Console.ReadLine();

            Application.Run(new MainMenu());

            //while (!File.Exists(filepath)){
            //Console.WriteLine("Already exists.");
            //Console.WriteLine("Input file path");
            //filepath = Console.ReadLine();
            //}

            //FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            //StreamReader sr = new StreamReader(filepath, Encoding.Default);
            //int[] signal_num = { 2, 4, 3, 2 };
            //vt.PIN_write(signal_num);


        }
        public VT() {
            this.PatNum_Site = new int[] { 10, 11, 11, 7, 9 };
            this.PatOrd_Site = new int[,] {
                { 0, 1, 3, 4, 5, 6, 7, 8, 9, 10, 10 },
                { 0, 1, 3, 4, 5, 6, 7, 8, 9, 3, 10 },
                { 0, 6, 2, 3, 1, 4, 5, 7, 8, 9, 10 },
                { 0, 1, 3, 4, 5, 7, 10, 10, 10, 10, 10 },
                { 0, 1, 3, 4, 5, 6, 7, 3, 10, 10, 10 }
            };
            this.DCODE_WHITE = 255;
            this.DCODE_BLACK = 133;
            this.DCODE_GRAY128 = 181;
            this.DCODE_GRAY64 = 176;
            this.pattern_count = 11;
            String w = "DCODE_WHITE";
            String b = "DCODE_BLACK";
            this.shader_data = new String[,] { 
                { "8'd128", "8'd128", "8'd128" }, 
                { b, b, b }, 
                { "DCODE_GRAY64", "DCODE_GRAY64", "DCODE_GRAY64" }, 
                { "DCODE_GRAY128", "DCODE_GRAY128", "DCODE_GRAY128" }, 
                { "pat_blc_wht_h[23:16]", "pat_blc_wht_h[15:8]", "pat_blc_wht_h[7:0]" }, 
                { "pat_wht_blc_h[23:16]", "pat_wht_blc_h[15:8]", "pat_wht_blc_h[7:0]" }, 
                { w, w, w }, 
                { w, b, b }, 
                { b, w, b }, 
                { b, b, w }, 
                { "8'd128", "8'd128", "8'd128" } };
        }

        public String TAB_KEY(int time)
        {
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < time; i++)
            {
                result.Append("\t");
            }
            return result.ToString();
        }

        public String COLOR_write()
        {
            StringWriter sw = new StringWriter();
            String IO_input = "\tinput\t\t\t";
            String IO_output = "\toutput\treg";
            String BITS_single = "\t\t\t\t";
            int[] port_bits = { 2, 6, 7, 11, 23 };
            String[] BITS_vector=new String[port_bits.Length];
            String[] Variable_Types = { "parameter\t\t", "reg\t\t\t\t", "wire\t\t\t\t" };

            for(int i = 0; i < port_bits.Length; i++)
            {
                if (port_bits[i] >= 10)
                {
                    BITS_vector[i] = "\t[" + port_bits[i].ToString() + ":0]\t";
                }
                else
                {
                    BITS_vector[i] = "\t[" + port_bits[i].ToString() + ":0]\t\t";
                }
            }
            sw.WriteLine("//此标记表明该代码由TOOL生成");
            sw.WriteLine("module shader(");
            sw.WriteLine(IO_input + BITS_single + "clk" + TAB_KEY(7));
            sw.WriteLine(IO_input + BITS_single + "rst_n" + TAB_KEY(7));
            sw.WriteLine(IO_input + BITS_vector[1] + "smp_dis_sn_pattern" + TAB_KEY(2));
            sw.WriteLine(IO_input + BITS_vector[0] + "dis_ctrl" + TAB_KEY(6));
            sw.WriteLine(IO_input + BITS_vector[0] + "VT1" + TAB_KEY(7));
            sw.WriteLine(IO_input + BITS_vector[0] + "VT2" + TAB_KEY(7));
            sw.WriteLine(IO_input + BITS_vector[0] + "AOI" + TAB_KEY(7));
            sw.WriteLine(IO_input + BITS_vector[0] + "Laser" + TAB_KEY(7));
            sw.WriteLine(IO_input + BITS_vector[0] + "VT2_jingjian" + TAB_KEY(4));
            sw.WriteLine(IO_input + BITS_vector[3] + "cnt_vact" + TAB_KEY(6));
            sw.WriteLine(IO_input + BITS_vector[3] + "V_ACT" + TAB_KEY(7));
            sw.WriteLine(IO_output + BITS_vector[2] + "r_data" + TAB_KEY(6));
            sw.WriteLine(IO_output + BITS_vector[2] + "g_data" + TAB_KEY(6));
            sw.WriteLine(IO_output + BITS_vector[2] + "b_data" + TAB_KEY(6));
            sw.WriteLine("");

            sw.WriteLine(Variable_Types[0] + BITS_single + "DCODE_WHITE" + TAB_KEY(4) + "=8'd" + this.DCODE_WHITE.ToString() + ";");
            sw.WriteLine(Variable_Types[0] + BITS_single + "DCODE_BLACK" + TAB_KEY(4) + "=8'd" + this.DCODE_BLACK.ToString() + ";");
            sw.WriteLine(Variable_Types[0] + BITS_single + "DCODE_GRAY128" + TAB_KEY(3) + "=8'd" + this.DCODE_GRAY128.ToString() + ";");
            sw.WriteLine(Variable_Types[0] + BITS_single + "DCODE_GRAY64" + TAB_KEY(3) + "=8'd" + this.DCODE_GRAY64.ToString() + ";");
            sw.WriteLine(Variable_Types[2] + BITS_vector[4] + "pat_blc_wht_h" + TAB_KEY(12) + ";");
            sw.WriteLine(Variable_Types[2] + BITS_vector[4] + "pat_wht_blc_h" + TAB_KEY(12) + ";");
            sw.WriteLine("");


            String[,] ubdw = { { "ubdw", "1'b1", "2'd2", "pat_blc_wht_h" }, { "uwdb", "1'b0", "2'd1", "pat_wht_blc_h" } };
            for(int i = 0; i < 2; i++)
            {
                sw.WriteLine("blackandwhite " + ubdw[i, 0] + "(");
                sw.WriteLine("\t.clk" + TAB_KEY(7) + "(clk" + TAB_KEY(7) + "),");
                sw.WriteLine("\t.rst_n" + TAB_KEY(6) + "(clk" + TAB_KEY(7) + "),");
                sw.WriteLine("\t.ubdw" + TAB_KEY(7) + "(" + ubdw[i, 1] + TAB_KEY(7) + "),");
                sw.WriteLine("\t.dis_ctrl" + TAB_KEY(5) + "(dis_ctrl" + TAB_KEY(5) + "),");
                sw.WriteLine("\t.VT1" + TAB_KEY(7) + "(VT1" + TAB_KEY(7) + "),");
                sw.WriteLine("\t.VT2" + TAB_KEY(7) + "(VT2" + TAB_KEY(7) + "),");
                sw.WriteLine("\t.Laser" + TAB_KEY(6) + "(Laser" + TAB_KEY(6) + "),");
                sw.WriteLine("\t.AOI" + TAB_KEY(7) + "(AOI" + TAB_KEY(7) + "),");
                sw.WriteLine("\t.VT2_jingjian" + TAB_KEY(4) + "(VT2_jingjian" + TAB_KEY(4) + "),");
                sw.WriteLine("\t.DCODE_WHITE" + TAB_KEY(4) + "(DCODE_WHITE" + TAB_KEY(4) + "),");
                sw.WriteLine("\t.DCODE_BLACK" + TAB_KEY(4) + "(DCODE_BLACK" + TAB_KEY(4) + "),");
                sw.WriteLine("\t.cnt_vact" + TAB_KEY(5) + "(cnt_vact" + TAB_KEY(5) + "),");
                sw.WriteLine("\t.V_ACT" + TAB_KEY(6) + "(V_ACT" + TAB_KEY(6) + "),");
                sw.WriteLine("\t.aoi_black_area" + TAB_KEY(3) + "(" + ubdw[i, 2] + TAB_KEY(7) + "),");
                sw.WriteLine("\t.pat_h" + TAB_KEY(6) + "(" + ubdw[i, 3] + TAB_KEY(4) + "),");
                sw.WriteLine(");");
                sw.WriteLine("");
            }

            sw.WriteLine("always @(posedge clk or negedge rst_n)");
            sw.WriteLine("begin");
            sw.WriteLine(TAB_KEY(1) + "if(rst_n==1'b0)");
            sw.WriteLine(TAB_KEY(1) + "begin");
            sw.WriteLine(TAB_KEY(2) + "r_data<=8'd0;");
            sw.WriteLine(TAB_KEY(2) + "g_data<=8'd0;");
            sw.WriteLine(TAB_KEY(2) + "b_data<=8'd0;");
            sw.WriteLine(TAB_KEY(1) + "end");
            sw.WriteLine(TAB_KEY(1) + "else");
            sw.WriteLine(TAB_KEY(1) + "begin");
            sw.WriteLine(TAB_KEY(2) + "case (smp_dis_sn_pattern)");
            for(int i = 0; i < this.pattern_count; i++)
            {
                sw.WriteLine(TAB_KEY(3) + "7'd" + i.ToString() + ":");
                sw.WriteLine(TAB_KEY(3) + "begin");
                sw.WriteLine(TAB_KEY(4) + "r_data=" + this.shader_data[i, 0] + ";");
                sw.WriteLine(TAB_KEY(4) + "g_data=" + this.shader_data[i, 1] + ";");
                sw.WriteLine(TAB_KEY(4) + "b_data=" + this.shader_data[i, 2] + ";");
                sw.WriteLine(TAB_KEY(3) + "end");
            }
            sw.WriteLine(TAB_KEY(2) + "endcase");
            sw.WriteLine(TAB_KEY(1) + "end");
            sw.WriteLine("end");
            sw.WriteLine("");
            sw.WriteLine("endmodule");

            return sw.ToString();
        }
        public String PATTERN_write()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("//此标记表明该代码由TOOL生成");
            sw.WriteLine("module test_sequence(");
            sw.WriteLine("input\tclk\t,");
            sw.WriteLine("input\trst_n\t,");
            sw.WriteLine("input\tNOTCH\t,");
            sw.WriteLine("input\t[2:0]\tdis_ctrl\t,");
            sw.WriteLine("input\t[2:0]\tVT1\t,");
            sw.WriteLine("input\t[2:0]\tVT2\t,");
            sw.WriteLine("input\t[2:0]\tAOI\t,");
            sw.WriteLine("input\t[2:0]\tLaser\t,");
            sw.WriteLine("input\t[2:0]\tVT2_jingjian\t,");
            sw.WriteLine("input\t[2:0]\tcs_ctrl\t,");
            sw.WriteLine("input\t[2:0]\tVBP\t,");
            sw.WriteLine("input\t[6:0]\tdis_sn\t,");
            sw.WriteLine("input\t[11:0]\tcnt_vblank\t,");
            sw.WriteLine("input\t[11:0]\thcnt\t,");
            sw.WriteLine("output\treg\t[6:0]\tPATMAX\t,");
            sw.WriteLine("output\treg\t[6:0]\tsmp_dis_sn_pattern\t,");
            sw.WriteLine("output\treg\t[6:0]\tsmp_dis_sn\t");
            sw.WriteLine(");");
            sw.WriteLine("");
            sw.WriteLine("always @(posedge clk or negedge rst_n)");
            sw.WriteLine("begin");
            sw.WriteLine("\tif (rst_n == 1'b0)");
            sw.WriteLine("\tbegin");
            sw.WriteLine("\t\tsmp_dis_sn <= 7'd0;");
            sw.WriteLine("\tend");
            sw.WriteLine("\telse");
            sw.WriteLine("\tbegin");
            sw.WriteLine("\t\tif ((cs_ctrl == VBP) && (cnt_vblank == 12'd0) && (hcnt == 12'd1))");
            sw.WriteLine("\t\tbegin");
            sw.WriteLine("\t\t\tsmp_dis_sn <= dis_sn;");
            for(int sites = 0; sites < 5; sites++)
            {
                switch (sites)
                {
                    case 1:
                        sw.WriteLine("\t\t\tif ((dis_ctrl == VT1) || ((dis_ctrl == VT2) && (NOTCH == 1'b0)))");
                        break;
                    case 2:
                        sw.WriteLine("\t\t\telse if ((dis_ctrl == VT2) && (NOTCH == 1'b1))");
                        break;
                    case 3:
                        sw.WriteLine("\t\t\telse if (dis_ctrl == AOI)");
                        break;
                    case 4:
                        sw.WriteLine("\t\t\telse if (dis_ctrl == Laser)");
                        break;
                    case 5:
                        sw.WriteLine("\t\t\telse if (dis_ctrl == VT2_jingjian)");
                        break;
                    default:
                        break;
                }
                sw.WriteLine("\t\t\tbegin");
                sw.WriteLine("\t\t\t\tPATMAX <= 7'd" + this.PatNum_Site[sites].ToString());
                sw.WriteLine("\t\t\t\tcase(smp_dis_sn)");
                for(int i=0; i < this.PatNum_Site[sites]; i++)
                {
                    sw.WriteLine("\t\t\t\t\t7'd" + i.ToString()+":");
                    sw.WriteLine("\t\t\t\t\tbegin");
                    sw.WriteLine("\t\t\t\t\t\tsmp_dis_sn_pattern <= 7'd" + this.PatOrd_Site[sites, i] + ";");
                    sw.WriteLine("\t\t\t\t\tend");
                }
                sw.WriteLine("\t\t\t\tendcase");
                sw.WriteLine("\t\t\tend");
            }
            sw.WriteLine("\t\tend");
            sw.WriteLine("\tend");
            sw.WriteLine("end");
            sw.WriteLine("");
            sw.WriteLine("endmodule");
            return sw.ToString();
        }
        public String SITE_write(String site)
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("//此标记表明该代码由TOOL生成");
            sw.WriteLine("module sites(");
            sw.WriteLine("\tinput\t\t\t\tclk\t\t\t,");
            sw.WriteLine("\tinput\t\t\t\trst_n\t\t\t,");
            sw.WriteLine("\tinput\t\t\t\t[2:0]\tcs_ctrl\t\t,");
            sw.WriteLine("\tinput\t\t\t\t[2:0]\tVBP\t\t,");
            sw.WriteLine("\tinput\t\t\t\t[6:0]\tdis_sn\t\t,");
            sw.WriteLine("\tinput\t\t\t\t[11:0]\tcnt_vblank\t,");
            sw.WriteLine("\tinput\t\t\t\t[11:0]\thcnt\t\t,");
            sw.WriteLine("\tinput\t\t\t\t[11:0]\tcnt_vact\t,");
            sw.WriteLine("\tinput\t\t\t\t[11:0]\tV_ACT\t\t,");
            sw.WriteLine("\toutput\t\t\t\t[6:0]\tPATMAX\t\t,");
            sw.WriteLine("\toutput\t\t\t\t[7:0]\tr_data\t\t,");
            sw.WriteLine("\toutput\t\t\t\t[7:0]\tg_data\t\t,");
            sw.WriteLine("\toutput\t\t\t\t[7:0]\tb_data\t\t,");
            sw.WriteLine("\toutput\t\t\t\tflag_pch\t\t,");
            sw.WriteLine("\toutput\t\t\t\tis_demux_all_on\t\t,");
            sw.WriteLine("\toutput\t\t\t\tflag_rev_scan\t\t,");
            sw.WriteLine("\toutput\t\t\t\t[6:0]\tsmp_dis_sn\t,");
            sw.WriteLine(");");
            sw.WriteLine("");
            sw.WriteLine("parameter\t\t\t\tNOTCH\t\t=1'b0\t\t;");
            sw.WriteLine("parameter\t\t\t\tVT1\t\t=3'd0\t\t;");
            sw.WriteLine("parameter\t\t\t\tVT2\t\t=3'd1\t\t;");
            sw.WriteLine("parameter\t\t\t\tLaser\t\t=3'd2\t\t;");
            sw.WriteLine("parameter\t\t\t\tAOI\t\t=3'd3\t\t;");
            sw.WriteLine("parameter\t\t\t\tVT2_jingjian\t=3'd4\t\t;");
            sw.WriteLine("parameter\t\t\t\tON_OFF20\t=3'd5\t\t;");
            sw.WriteLine("parameter\t\t\t\tdis_ctrl\t="+site+"\t\t;");
            sw.WriteLine("");
            sw.WriteLine("wire\t\t\t\t[6:0]\tsmp_dis_sn_patter\t;");
            sw.WriteLine("");
            sw.WriteLine("shader u_shader(");
            sw.WriteLine("\t.clk\t\t\t\t(clk\t\t\t\t\t),");
            sw.WriteLine("\t.rst_n\t\t\t\t(rst_n\t\t\t\t\t),");
            sw.WriteLine("\t.smp_dis_sn_pattern\t\t(smp_dis_sn_pattern\t\t\t),");
            sw.WriteLine("\t.dis_ctrl\t\t\t(dis_ctrl\t\t\t\t),");
            sw.WriteLine("\t.VT1\t\t\t\t(VT1\t\t\t\t\t),");
            sw.WriteLine("\t.VT2\t\t\t\t(VT2\t\t\t\t\t),");
            sw.WriteLine("\t.AOI\t\t\t\t(AOI\t\t\t\t\t),");
            sw.WriteLine("\t.Laser\t\t\t\t(Laser\t\t\t\t\t),");
            sw.WriteLine("\t.VT2_jingjian\t\t\t(VT2_jingjian\t\t\t\t),");
            sw.WriteLine("\t.cnt_vact\t\t\t(cnt_vact\t\t\t\t),");
            sw.WriteLine("\t.V_ACT\t\t\t\t(V_ACT\t\t\t\t\t),");
            sw.WriteLine("\t.r_data\t\t\t\t(r_data\t\t\t\t\t),");
            sw.WriteLine("\t.g_data\t\t\t\t(g_data\t\t\t\t\t),");
            sw.WriteLine("\t.b_data\t\t\t\t(b_data\t\t\t\t\t)");
            sw.WriteLine(");");
            sw.WriteLine("");
            sw.WriteLine("test_sequence u_test_sequence(");
            sw.WriteLine("\t.clk\t\t\t\t(clk\t\t\t\t\t),");
            sw.WriteLine("\t.rst_n\t\t\t\t(rst_n\t\t\t\t\t),");
            sw.WriteLine("\t.NOTCH\t\t\t\t(NOTCH\t\t\t\t\t),");
            sw.WriteLine("\t.dis_ctrl\t\t\t(dis_ctrl\t\t\t\t),");
            sw.WriteLine("\t.VT1\t\t\t\t(VT1\t\t\t\t\t),");
            sw.WriteLine("\t.VT2\t\t\t\t(VT2\t\t\t\t\t),");
            sw.WriteLine("\t.AOI\t\t\t\t(AOI\t\t\t\t\t),");
            sw.WriteLine("\t.Laser\t\t\t\t(Laser\t\t\t\t\t),");
            sw.WriteLine("\t.VT2_jingjian\t\t\t(VT2_jingjian\t\t\t\t),");
            sw.WriteLine("\t.cs_ctrl\t\t\t(cs_ctrl\t\t\t\t),");
            sw.WriteLine("\t.VBP\t\t\t\t(VBP\t\t\t\t\t),");
            sw.WriteLine("\t.dis_sn\t\t\t\t(dis_sn\t\t\t\t\t),");
            sw.WriteLine("\t.cnt_vblank\t\t\t(cnt_vblank\t\t\t\t),");
            sw.WriteLine("\t.hcnt\t\t\t\t(hcnt\t\t\t\t\t),");
            sw.WriteLine("\t.PATMAX\t\t\t\t(PATMAX\t\t\t\t\t),");
            sw.WriteLine("\t.smp_dis_sn_pattern\t\t(smp_dis_sn_pattern\t\t\t),");
            sw.WriteLine("\t.smp_dis_sn\t\t\t(smp_dis_sn\t\t\t\t)");
            sw.WriteLine(");");
            sw.WriteLine("");
            sw.WriteLine("mode u_mode(");
            sw.WriteLine("\t.VT1\t\t\t\t(VT1\t\t\t\t\t),");
            sw.WriteLine("\t.VT2\t\t\t\t(VT2\t\t\t\t\t),");
            sw.WriteLine("\t.AOI\t\t\t\t(AOI\t\t\t\t\t),");
            sw.WriteLine("\t.Laser\t\t\t\t(Laser\t\t\t\t\t),");
            sw.WriteLine("\t.VT2_jingjian\t\t\t(VT2_jingjian\t\t\t),");
            sw.WriteLine("\t.ON_OFF20\t\t\t(ON_OFF20\t\t\t\t),");
            sw.WriteLine("\t.dis_ctrl\t\t\t(dis_ctrl\t\t\t\t),");
            sw.WriteLine("\t.smp_dis_sn\t\t\t(smp_dis_sn\t\t\t\t)");
            sw.WriteLine("\t.cnt_vact\t\t\t(cnt_vact\t\t\t\t),");
            sw.WriteLine("\t.V_ACT\t\t\t\t(V_ACT\t\t\t\t\t),");
            sw.WriteLine("\t.flag_pch\t\t\t(flag_pch\t\t\t\t),");
            sw.WriteLine("\t.is_demux_all_on\t\t(is_demux_all_on\t\t),");
            sw.WriteLine("\t.flag_rev_scan\t\t\t(flag_rev_scan\t\t\t)");
            sw.WriteLine(");");
            sw.WriteLine("");
            sw.WriteLine("endmodule");
            return sw.ToString();
        }
        public String PIN_write()
        {
            StringWriter sw = new StringWriter();
            //开始写入
            sw.WriteLine("//此标记表明该代码由TOOL生成");
            sw.WriteLine("module\tmux_array(");
            sw.WriteLine("\tinput\t\tCMOS\t\t\t\t\t,");
            sw.WriteLine("\tinput\t\tclk_sys\t\t\t,");
            sw.WriteLine("//TIMING");
            int i;

            sw.WriteLine("//stv");
            Console.WriteLine("How many stv are in your project ?");
            //stv_num = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= this.SignalNum[0]; i++)
            {
                sw.WriteLine("input\t\tstv" + i + "\t\t\t\t\t,");
            }
            sw.WriteLine("//ckv");
            Console.WriteLine("How many ckv are in your project ?");
            //ckv_num = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= SignalNum[1]; i++)
            {
                sw.WriteLine("input\t\tckv" + i + "\t\t\t\t\t,");
            }

            sw.WriteLine("//ckh");
            Console.WriteLine("How many ckh are in your project ? (xckh are not included)");
            //ckh_num = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= SignalNum[2]; i++)
            {
                sw.WriteLine("input\t\tckh" + i + "\t\t\t\t\t,");
            }

            sw.WriteLine("//grst");
            sw.WriteLine("input\t\tgrst\t\t\t\t\t,");
            sw.WriteLine("//gas");
            sw.WriteLine("input\t\tgas\t\t\t\t\t,");
            sw.WriteLine("//jdqi");
            sw.WriteLine("input\t\tjdqi\t\t\t\t\t,");
            sw.WriteLine("//u2d");
            sw.WriteLine("input\t\tu2d\t\t\t\t\t,");
            sw.WriteLine("//d2u");
            sw.WriteLine("input\t\td2u\t\t\t\t\t,");

            sw.WriteLine("//vtcomsw");
            Console.WriteLine("How many vtcomsw are in your project ?");
            //vtcomsw_num = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= SignalNum[3]; i++){
                sw.WriteLine("input\t\tVTCOMSW" + i + "\t\t\t,");
            }
            for (i = 1; i <= 14; i++){
                sw.WriteLine("\toutput\tmux_" + i + "\t\t\t\t\t,");
            }
            for (i = 1; i <= 2; i++){
                sw.WriteLine("\toutput\tmux_Test" + i + "\t\t\t,");
            }
            sw.WriteLine(");");
            sw.WriteLine();
            for (i = 1; i <= SignalNum[2]; i++){
                sw.WriteLine("wire\t\t\txckh" + i + "\t=(CMOS==1'b0)?1'b0:~ckh"+i);
            }
            sw.WriteLine();

            for (i = 1; i <= 14; i++){
                sw.WriteLine("mux_decode u" + i.ToString().PadLeft(2, '0') + "_mux_decode(");
                sw.WriteLine("\tclk\t\t(clk_sys\t\t\t),");
                Console.WriteLine("Specify signal for mux" + i + ", Port A");
                //String Temp = Console.ReadLine();
                String Temp = this.Signals[i-1, 0];
                if (Temp.Length == 0){
                    sw.WriteLine("\t.da\t\t(" + "1'b0" + "\t\t\t\t),");
                }
                else{
                    sw.WriteLine("\t.da\t\t(" + Temp + "\t\t\t\t),");
                }

                if (Temp.Contains("ckh")){
                    Console.WriteLine("Autogen XCKH palceholder...");
                    sw.WriteLine("\t.db\t\t(xckh" + Temp.Substring(Temp.IndexOf("ckh")+3,1) + "\t\t\t\t),");
                }
                else{ 
                    //Boolean isCKH=true;
                    //while (isCKH){
                        Console.WriteLine("Specify signal for mux" + i + ", Port B");
                        //Temp = Console.ReadLine();
                        Temp = this.Signals[i-1, 1];
                        if (Temp.Contains("ckh")){
                            Console.WriteLine("WARNING: ");
                            Console.WriteLine("Port B is logically inappropriate for CKH signals !");
                        }
                        //else{
                            //isCKH = false;
                        //}
                    //}
                    if (Temp.Length == 0){
                        sw.WriteLine("\t.db\t\t(" + "1'b0" + "\t\t\t\t),");
                    }
                    else{
                        sw.WriteLine("\t.db\t\t(" + Temp + "\t\t\t\t),");
                    }
                }
                sw.WriteLine("\t.a\t\t(mux_"+i+"\t\t\t\t)");
                sw.WriteLine(");");
                sw.WriteLine("");
            }
            sw.WriteLine("");
            sw.WriteLine("endmodule");
            return sw.ToString();

        }
        void PIN_read(StreamReader sr) {
            String line;
            while (true){
                line = sr.ReadLine();
                if (line.Equals("//PIN"))
                    break;
            }
            int i = 0;
            int k = 0;
            int No;
            int stop;
            String temp;
            while ((line = sr.ReadLine()).Equals("//PIN") == false){
                this.Contents[i] = line;
                if (k < 14 && line.Contains("mux_decode")){
                    No = line.IndexOf("mux_decode u");
                    //this.Signals[k, 0] = line.Substring(No + 12, 2);
                }
                if (k < 14 && line.Contains("da")){
                    No = line.IndexOf("(");
                    temp = line.Substring(No + 1, 10);
                    temp = temp.TrimStart(' ');
                    stop = temp.IndexOf(" ");
                    if (stop <= 0) {
                        stop = temp.IndexOf("\t");
                    }
                    this.Signals[k, 0] = temp.Remove(stop);
                }
                if (k < 14 && line.Contains("db")){
                    No = line.IndexOf("(");
                    temp = line.Substring(No + 1, 10);
                    temp = temp.TrimStart(' ');
                    stop = temp.IndexOf(" ");
                    if (stop <= 0)
                    {
                        stop = temp.IndexOf("\t");
                    }
                    this.Signals[k, 1] = temp.Remove(stop);
                }
                if (k < 14 && line.Contains(".a")){
                    k++;
                }
                i++;
            }
            int j = 0;
            Console.ReadLine();
            for (i = k; i > 0; i--){
                Console.WriteLine("MUX: " + (j+1).ToString());
                Console.WriteLine("DA: " + Signals[j, 1]);
                Console.WriteLine("DB: " + Signals[j, 2]);
                Console.ReadLine();
                j++;
            }

        }
    }
}
