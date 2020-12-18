namespace VCG
{
    partial class MainMenu
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
            this.SetPins = new System.Windows.Forms.Button();
            this.SetSites = new System.Windows.Forms.Button();
            this.SetPatterns = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetPins
            // 
            this.SetPins.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetPins.Location = new System.Drawing.Point(12, 12);
            this.SetPins.Name = "SetPins";
            this.SetPins.Size = new System.Drawing.Size(177, 38);
            this.SetPins.TabIndex = 0;
            this.SetPins.Text = "Pin定义配置";
            this.SetPins.UseVisualStyleBackColor = true;
            this.SetPins.Click += new System.EventHandler(this.SetPins_Click);
            // 
            // SetSites
            // 
            this.SetSites.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetSites.Location = new System.Drawing.Point(12, 66);
            this.SetSites.Name = "SetSites";
            this.SetSites.Size = new System.Drawing.Size(177, 38);
            this.SetSites.TabIndex = 1;
            this.SetSites.Text = "站点设置";
            this.SetSites.UseVisualStyleBackColor = true;
            this.SetSites.Click += new System.EventHandler(this.button2_Click);
            // 
            // SetPatterns
            // 
            this.SetPatterns.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetPatterns.Location = new System.Drawing.Point(12, 120);
            this.SetPatterns.Name = "SetPatterns";
            this.SetPatterns.Size = new System.Drawing.Size(177, 38);
            this.SetPatterns.TabIndex = 2;
            this.SetPatterns.Text = "分显图顺序";
            this.SetPatterns.UseVisualStyleBackColor = true;
            this.SetPatterns.Click += new System.EventHandler(this.SetPatterns_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(12, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "分显图着色";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SetPatterns);
            this.Controls.Add(this.SetSites);
            this.Controls.Add(this.SetPins);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetPins;
        private System.Windows.Forms.Button SetSites;
        private System.Windows.Forms.Button SetPatterns;
        private System.Windows.Forms.Button button1;
    }
}