namespace GroupProjectDJT
{
    partial class Home
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
            this.homePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.homePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // homePanel
            // 
            this.homePanel.Controls.Add(this.label1);
            this.homePanel.Location = new System.Drawing.Point(12, 12);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(760, 522);
            this.homePanel.TabIndex = 0;
            this.homePanel.Tag = "Home";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 548);
            this.Controls.Add(this.homePanel);
            this.Name = "Home";
            this.Text = "Home";
            this.homePanel.ResumeLayout(false);
            this.homePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel homePanel;
        private System.Windows.Forms.Label label1;
    }
}