namespace VCG
{
    partial class SetSites
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
            this.SitesBox = new System.Windows.Forms.ComboBox();
            this.SelectSite = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
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
            this.SitesBox.Location = new System.Drawing.Point(12, 12);
            this.SitesBox.Name = "SitesBox";
            this.SitesBox.Size = new System.Drawing.Size(271, 20);
            this.SitesBox.TabIndex = 0;
            this.SitesBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SelectSite
            // 
            this.SelectSite.Location = new System.Drawing.Point(293, 12);
            this.SelectSite.Name = "SelectSite";
            this.SelectSite.Size = new System.Drawing.Size(271, 20);
            this.SelectSite.TabIndex = 1;
            this.SelectSite.Text = "Confirm";
            this.SelectSite.UseVisualStyleBackColor = true;
            this.SelectSite.Click += new System.EventHandler(this.SelectSite_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.AcceptsTab = true;
            this.OutputBox.Location = new System.Drawing.Point(12, 38);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(552, 340);
            this.OutputBox.TabIndex = 2;
            this.OutputBox.Text = "啥也不选，默认站点为VT1";
            // 
            // SetSites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 390);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.SelectSite);
            this.Controls.Add(this.SitesBox);
            this.Name = "SetSites";
            this.Text = "SetSites";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SitesBox;
        private System.Windows.Forms.Button SelectSite;
        private System.Windows.Forms.RichTextBox OutputBox;
    }
}