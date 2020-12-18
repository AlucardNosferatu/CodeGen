namespace VCG
{
    partial class SetPatterns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.PatNum = new System.Windows.Forms.TextBox();
            this.SetPN = new System.Windows.Forms.Button();
            this.PatBox = new System.Windows.Forms.ComboBox();
            this.ShaderNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SitesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "分显图个数：";
            // 
            // PatNum
            // 
            this.PatNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PatNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatNum.Location = new System.Drawing.Point(147, 37);
            this.PatNum.Name = "PatNum";
            this.PatNum.Size = new System.Drawing.Size(106, 26);
            this.PatNum.TabIndex = 1;
            this.PatNum.TextChanged += new System.EventHandler(this.PatNum_TextChanged);
            // 
            // SetPN
            // 
            this.SetPN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetPN.Location = new System.Drawing.Point(12, 71);
            this.SetPN.Name = "SetPN";
            this.SetPN.Size = new System.Drawing.Size(241, 42);
            this.SetPN.TabIndex = 2;
            this.SetPN.Text = "确定";
            this.SetPN.UseVisualStyleBackColor = true;
            this.SetPN.Click += new System.EventHandler(this.SetPN_VT1_Click);
            // 
            // PatBox
            // 
            this.PatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PatBox.FormattingEnabled = true;
            this.PatBox.Location = new System.Drawing.Point(147, 121);
            this.PatBox.Name = "PatBox";
            this.PatBox.Size = new System.Drawing.Size(106, 20);
            this.PatBox.TabIndex = 3;
            this.PatBox.SelectedIndexChanged += new System.EventHandler(this.PatBox_SelectedIndexChanged);
            // 
            // ShaderNo
            // 
            this.ShaderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShaderNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShaderNo.Location = new System.Drawing.Point(147, 149);
            this.ShaderNo.Name = "ShaderNo";
            this.ShaderNo.Size = new System.Drawing.Size(106, 26);
            this.ShaderNo.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(12, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 46);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SitesBox
            // 
            this.SitesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SitesBox.FormattingEnabled = true;
            this.SitesBox.Items.AddRange(new object[] {
            "VT1",
            "VT2",
            "镭射",
            "AOI",
            "VT2精简版"});
            this.SitesBox.Location = new System.Drawing.Point(147, 9);
            this.SitesBox.Name = "SitesBox";
            this.SitesBox.Size = new System.Drawing.Size(106, 20);
            this.SitesBox.TabIndex = 11;
            this.SitesBox.SelectedIndexChanged += new System.EventHandler(this.SitesBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "请选择站点：";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "分显图序号：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "着色器编号：";
            // 
            // OutputBox
            // 
            this.OutputBox.AcceptsTab = true;
            this.OutputBox.Location = new System.Drawing.Point(259, 9);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(622, 457);
            this.OutputBox.TabIndex = 14;
            this.OutputBox.Text = "";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(147, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 46);
            this.button2.TabIndex = 15;
            this.button2.Text = "生成代码";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(12, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 46);
            this.button3.TabIndex = 16;
            this.button3.Text = "默认配置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SetPatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 478);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SitesBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PatNum);
            this.Controls.Add(this.SetPN);
            this.Controls.Add(this.ShaderNo);
            this.Controls.Add(this.PatBox);
            this.Name = "SetPatterns";
            this.Text = "SetPatterns";
            this.Load += new System.EventHandler(this.SetPatterns_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PatNum;
        private System.Windows.Forms.Button SetPN;
        private System.Windows.Forms.ComboBox PatBox;
        private System.Windows.Forms.TextBox ShaderNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox SitesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}