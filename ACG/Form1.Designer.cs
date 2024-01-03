namespace ACG
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.jsonInputBox = new System.Windows.Forms.RichTextBox();
            this.parseJson = new System.Windows.Forms.Button();
            this.genProxyIn = new System.Windows.Forms.Button();
            this.genProxyOut = new System.Windows.Forms.Button();
            this.genProxyURL = new System.Windows.Forms.Button();
            this.genRFKeyword = new System.Windows.Forms.Button();
            this.pout_url_tbox = new System.Windows.Forms.TextBox();
            this.pout_url_label = new System.Windows.Forms.Label();
            this.pout_path_label = new System.Windows.Forms.Label();
            this.pout_path_tbox = new System.Windows.Forms.TextBox();
            this.pin_file_label = new System.Windows.Forms.Label();
            this.pin_file_tbox = new System.Windows.Forms.TextBox();
            this.sp_an_tbox = new System.Windows.Forms.TextBox();
            this.sp_an_label = new System.Windows.Forms.Label();
            this.cmd_str_label = new System.Windows.Forms.Label();
            this.cmd_str_tbox = new System.Windows.Forms.TextBox();
            this.is_cmd_cbox = new System.Windows.Forms.CheckBox();
            this.get_result_cbox = new System.Windows.Forms.CheckBox();
            this.has_em_cbox = new System.Windows.Forms.CheckBox();
            this.pin_url_label = new System.Windows.Forms.Label();
            this.pin_url_tbox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.jsonExample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jsonInputBox
            // 
            this.jsonInputBox.Location = new System.Drawing.Point(13, 13);
            this.jsonInputBox.Name = "jsonInputBox";
            this.jsonInputBox.Size = new System.Drawing.Size(405, 174);
            this.jsonInputBox.TabIndex = 0;
            this.jsonInputBox.Text = "把Json文本粘贴在这\n\"#VAR_UNI\"代表相同键值用不同参数传参\n\"#VAR_COM\"代表相同键值用相同参数传参\n\"#TD\"代表时间表（用于定时重启等）\n\"" +
    "#TS\"代表时间戳（configId/configTime/currentTime）\n";
            this.jsonInputBox.WordWrap = false;
            // 
            // parseJson
            // 
            this.parseJson.Location = new System.Drawing.Point(672, 12);
            this.parseJson.Name = "parseJson";
            this.parseJson.Size = new System.Drawing.Size(116, 52);
            this.parseJson.TabIndex = 1;
            this.parseJson.Text = "解析Json";
            this.parseJson.UseVisualStyleBackColor = true;
            this.parseJson.Click += new System.EventHandler(this.parseJson_Click);
            // 
            // genProxyIn
            // 
            this.genProxyIn.Location = new System.Drawing.Point(428, 13);
            this.genProxyIn.Name = "genProxyIn";
            this.genProxyIn.Size = new System.Drawing.Size(116, 52);
            this.genProxyIn.TabIndex = 2;
            this.genProxyIn.Text = "生成Django\r\n接口函数";
            this.genProxyIn.UseVisualStyleBackColor = true;
            this.genProxyIn.Click += new System.EventHandler(this.genProxyIn_Click);
            // 
            // genProxyOut
            // 
            this.genProxyOut.Location = new System.Drawing.Point(550, 13);
            this.genProxyOut.Name = "genProxyOut";
            this.genProxyOut.Size = new System.Drawing.Size(116, 52);
            this.genProxyOut.TabIndex = 3;
            this.genProxyOut.Text = "生成请求函数";
            this.genProxyOut.UseVisualStyleBackColor = true;
            this.genProxyOut.Click += new System.EventHandler(this.genProxyOut_Click);
            // 
            // genProxyURL
            // 
            this.genProxyURL.Location = new System.Drawing.Point(428, 71);
            this.genProxyURL.Name = "genProxyURL";
            this.genProxyURL.Size = new System.Drawing.Size(116, 52);
            this.genProxyURL.TabIndex = 4;
            this.genProxyURL.Text = "生成Django\r\n接口URL";
            this.genProxyURL.UseVisualStyleBackColor = true;
            this.genProxyURL.Click += new System.EventHandler(this.genProxyURL_Click);
            // 
            // genRFKeyword
            // 
            this.genRFKeyword.Location = new System.Drawing.Point(550, 71);
            this.genRFKeyword.Name = "genRFKeyword";
            this.genRFKeyword.Size = new System.Drawing.Size(116, 52);
            this.genRFKeyword.TabIndex = 5;
            this.genRFKeyword.Text = "生成RF关键字\r\n函数";
            this.genRFKeyword.UseVisualStyleBackColor = true;
            this.genRFKeyword.Click += new System.EventHandler(this.genRFKeyword_Click);
            // 
            // pout_url_tbox
            // 
            this.pout_url_tbox.Location = new System.Drawing.Point(428, 144);
            this.pout_url_tbox.Name = "pout_url_tbox";
            this.pout_url_tbox.Size = new System.Drawing.Size(360, 25);
            this.pout_url_tbox.TabIndex = 6;
            this.pout_url_tbox.Text = "homewlan/sta/setStaRemark2";
            // 
            // pout_url_label
            // 
            this.pout_url_label.AutoSize = true;
            this.pout_url_label.Location = new System.Drawing.Point(425, 126);
            this.pout_url_label.Name = "pout_url_label";
            this.pout_url_label.Size = new System.Drawing.Size(130, 15);
            this.pout_url_label.TabIndex = 7;
            this.pout_url_label.Text = "APP服务器接口URL";
            // 
            // pout_path_label
            // 
            this.pout_path_label.AutoSize = true;
            this.pout_path_label.Location = new System.Drawing.Point(425, 172);
            this.pout_path_label.Name = "pout_path_label";
            this.pout_path_label.Size = new System.Drawing.Size(293, 15);
            this.pout_path_label.TabIndex = 8;
            this.pout_path_label.Text = "请求函数所在py文件路径（相对工作路径）";
            // 
            // pout_path_tbox
            // 
            this.pout_path_tbox.Location = new System.Drawing.Point(428, 190);
            this.pout_path_tbox.Name = "pout_path_tbox";
            this.pout_path_tbox.Size = new System.Drawing.Size(360, 25);
            this.pout_path_tbox.TabIndex = 9;
            this.pout_path_tbox.Text = "utils.api.app_v2.functions.frontpage.set_alias";
            // 
            // pin_file_label
            // 
            this.pin_file_label.AutoSize = true;
            this.pin_file_label.Location = new System.Drawing.Point(425, 218);
            this.pin_file_label.Name = "pin_file_label";
            this.pin_file_label.Size = new System.Drawing.Size(296, 15);
            this.pin_file_label.TabIndex = 10;
            this.pin_file_label.Text = "Django接口函数所在py文件（只要文件名）";
            // 
            // pin_file_tbox
            // 
            this.pin_file_tbox.Location = new System.Drawing.Point(428, 236);
            this.pin_file_tbox.Name = "pin_file_tbox";
            this.pin_file_tbox.Size = new System.Drawing.Size(360, 25);
            this.pin_file_tbox.TabIndex = 11;
            this.pin_file_tbox.Text = "frontpage";
            // 
            // sp_an_tbox
            // 
            this.sp_an_tbox.Location = new System.Drawing.Point(428, 328);
            this.sp_an_tbox.Name = "sp_an_tbox";
            this.sp_an_tbox.Size = new System.Drawing.Size(360, 25);
            this.sp_an_tbox.TabIndex = 13;
            // 
            // sp_an_label
            // 
            this.sp_an_label.AutoSize = true;
            this.sp_an_label.Location = new System.Drawing.Point(425, 310);
            this.sp_an_label.Name = "sp_an_label";
            this.sp_an_label.Size = new System.Drawing.Size(337, 15);
            this.sp_an_label.TabIndex = 12;
            this.sp_an_label.Text = "指定动作名（用于标识接口动作，留空自动生成）";
            // 
            // cmd_str_label
            // 
            this.cmd_str_label.AutoSize = true;
            this.cmd_str_label.Location = new System.Drawing.Point(425, 356);
            this.cmd_str_label.Name = "cmd_str_label";
            this.cmd_str_label.Size = new System.Drawing.Size(243, 15);
            this.cmd_str_label.TabIndex = 14;
            this.cmd_str_label.Text = "sendCmd字符串（专用接口不用写）";
            // 
            // cmd_str_tbox
            // 
            this.cmd_str_tbox.Location = new System.Drawing.Point(428, 374);
            this.cmd_str_tbox.Name = "cmd_str_tbox";
            this.cmd_str_tbox.Size = new System.Drawing.Size(360, 25);
            this.cmd_str_tbox.TabIndex = 15;
            this.cmd_str_tbox.Text = "ac_config set -m timeReboot \'{}\'";
            // 
            // is_cmd_cbox
            // 
            this.is_cmd_cbox.AutoSize = true;
            this.is_cmd_cbox.Location = new System.Drawing.Point(428, 412);
            this.is_cmd_cbox.Name = "is_cmd_cbox";
            this.is_cmd_cbox.Size = new System.Drawing.Size(85, 19);
            this.is_cmd_cbox.TabIndex = 16;
            this.is_cmd_cbox.Text = "sendCmd";
            this.is_cmd_cbox.UseVisualStyleBackColor = true;
            // 
            // get_result_cbox
            // 
            this.get_result_cbox.AutoSize = true;
            this.get_result_cbox.Location = new System.Drawing.Point(519, 412);
            this.get_result_cbox.Name = "get_result_cbox";
            this.get_result_cbox.Size = new System.Drawing.Size(101, 19);
            this.get_result_cbox.TabIndex = 17;
            this.get_result_cbox.Text = "getResult";
            this.get_result_cbox.UseVisualStyleBackColor = true;
            // 
            // has_em_cbox
            // 
            this.has_em_cbox.AutoSize = true;
            this.has_em_cbox.Location = new System.Drawing.Point(626, 404);
            this.has_em_cbox.Name = "has_em_cbox";
            this.has_em_cbox.Size = new System.Drawing.Size(104, 34);
            this.has_em_cbox.TabIndex = 18;
            this.has_em_cbox.Text = "时间表\r\n有结束时间";
            this.has_em_cbox.UseVisualStyleBackColor = true;
            // 
            // pin_url_label
            // 
            this.pin_url_label.AutoSize = true;
            this.pin_url_label.Location = new System.Drawing.Point(425, 264);
            this.pin_url_label.Name = "pin_url_label";
            this.pin_url_label.Size = new System.Drawing.Size(139, 15);
            this.pin_url_label.TabIndex = 19;
            this.pin_url_label.Text = "Django接口URL前缀";
            // 
            // pin_url_tbox
            // 
            this.pin_url_tbox.Location = new System.Drawing.Point(428, 282);
            this.pin_url_tbox.Name = "pin_url_tbox";
            this.pin_url_tbox.Size = new System.Drawing.Size(360, 25);
            this.pin_url_tbox.TabIndex = 20;
            this.pin_url_tbox.Text = "functions/v2/frontpage/";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 193);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(405, 238);
            this.outputBox.TabIndex = 21;
            this.outputBox.Text = "输出结果";
            this.outputBox.WordWrap = false;
            // 
            // jsonExample
            // 
            this.jsonExample.Location = new System.Drawing.Point(672, 71);
            this.jsonExample.Name = "jsonExample";
            this.jsonExample.Size = new System.Drawing.Size(116, 52);
            this.jsonExample.TabIndex = 22;
            this.jsonExample.Text = "Json文本范例";
            this.jsonExample.UseVisualStyleBackColor = true;
            this.jsonExample.Click += new System.EventHandler(this.jsonExample_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.jsonExample);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.pin_url_tbox);
            this.Controls.Add(this.pin_url_label);
            this.Controls.Add(this.has_em_cbox);
            this.Controls.Add(this.get_result_cbox);
            this.Controls.Add(this.is_cmd_cbox);
            this.Controls.Add(this.cmd_str_tbox);
            this.Controls.Add(this.cmd_str_label);
            this.Controls.Add(this.sp_an_tbox);
            this.Controls.Add(this.sp_an_label);
            this.Controls.Add(this.pin_file_tbox);
            this.Controls.Add(this.pin_file_label);
            this.Controls.Add(this.pout_path_tbox);
            this.Controls.Add(this.pout_path_label);
            this.Controls.Add(this.pout_url_label);
            this.Controls.Add(this.pout_url_tbox);
            this.Controls.Add(this.genRFKeyword);
            this.Controls.Add(this.genProxyURL);
            this.Controls.Add(this.genProxyOut);
            this.Controls.Add(this.genProxyIn);
            this.Controls.Add(this.parseJson);
            this.Controls.Add(this.jsonInputBox);
            this.Name = "MainForm";
            this.Text = "APP自动化-自动化代码生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox jsonInputBox;
        private System.Windows.Forms.Button parseJson;
        private System.Windows.Forms.Button genProxyIn;
        private System.Windows.Forms.Button genProxyOut;
        private System.Windows.Forms.Button genProxyURL;
        private System.Windows.Forms.Button genRFKeyword;
        private System.Windows.Forms.TextBox pout_url_tbox;
        private System.Windows.Forms.Label pout_url_label;
        private System.Windows.Forms.Label pout_path_label;
        private System.Windows.Forms.TextBox pout_path_tbox;
        private System.Windows.Forms.Label pin_file_label;
        private System.Windows.Forms.TextBox pin_file_tbox;
        private System.Windows.Forms.TextBox sp_an_tbox;
        private System.Windows.Forms.Label sp_an_label;
        private System.Windows.Forms.Label cmd_str_label;
        private System.Windows.Forms.TextBox cmd_str_tbox;
        private System.Windows.Forms.CheckBox is_cmd_cbox;
        private System.Windows.Forms.CheckBox get_result_cbox;
        private System.Windows.Forms.CheckBox has_em_cbox;
        private System.Windows.Forms.Label pin_url_label;
        private System.Windows.Forms.TextBox pin_url_tbox;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Button jsonExample;
    }
}

